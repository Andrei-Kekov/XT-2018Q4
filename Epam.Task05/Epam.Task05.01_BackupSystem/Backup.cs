using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public static class Program
{
    private const string WATCH_PARAMETER = "/w";
    private const string RESTORE_PARAMETER = "/r";
    private const string BACKUP_FOLDER_NAME = "Backup";
    private const string LOG_FILENAME = "log.txt";
    private const int COPY_DELAY = 100;
    private static string backupPath;
    private static string watchPath;
    private static DirectoryInfo backup;
    private static Dictionary<DateTime, FileSystemEventArgs> log;
    private static SortedList<DateTime, FileSystemEventArgs> logSorted;
    private static FileSystemWatcher watcher;

    public static void Main(string[] args)
    {
        Console.WriteLine("Task 5.1. Backup System");

        if (args.Length != 2)
        {
            Help();
            return;
        }

        backupPath = Path.GetFullPath(BACKUP_FOLDER_NAME);
        watchPath = Path.GetFullPath(args[1]);
        backup = new DirectoryInfo(backupPath);

        if (args[0].Equals(WATCH_PARAMETER))
        {
            if (Directory.Exists(watchPath))
            {
                Console.WriteLine("The directory you specified doesn't exist.");
                return;
            }

            Watch();
        }
        else if (args[0].Equals(RESTORE_PARAMETER))
        {
            if (Directory.Exists(watchPath))
            {
                Console.WriteLine("The directory you specified doesn't exist.");
                return;
            }

            Restore();
        }
        else
        {
            Help();
            return;
        }        
    }

    public static void Help()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine($"backup {WATCH_PARAMETER} <path>\t- start watching the folder");
        Console.WriteLine($"backup {RESTORE_PARAMETER}\t\t- restore the folder");
    }

    public static void Watch()
    {        
        try
        {
            LoadLog();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Log file not found.");
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Warning! Failed to load the log file! Reason: {exc.Message}");
        }

        if (!backup.Exists)
        {
            backup.Create();
        }        

        watcher = new FileSystemWatcher(watchPath, "*.txt");
        watcher.Created += new FileSystemEventHandler(OnCreated);
        watcher.Deleted += new FileSystemEventHandler(OnDeleted);
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.EnableRaisingEvents = true;
        Console.WriteLine($"Watching the directory: {watchPath}");
        Console.WriteLine("Press 'q' to exit.");

        while (Console.Read() != 'q')
        {
        }

        SaveLog();
    }    

    public static void OnCreated(object source, FileSystemEventArgs e)
    {
        DateTime time = DateTime.Now;

        if (log.ContainsKey(time))
        {
            log[time] = e;
        }
        else
        {
            log.Add(time, e);
        }

        Console.WriteLine($"{e.ChangeType}\t{e.FullPath}");
        Thread.Sleep(COPY_DELAY);
        File.Copy(e.FullPath, Path.Combine(backupPath, Hash(time, e).ToString()));
    }

    public static void OnDeleted(object source, FileSystemEventArgs e)
    {
        DateTime time = DateTime.Now;

        if (log.ContainsKey(time))
        {
            log[time] = e;
        }
        else
        {
            log.Add(time, e);
        }

        Console.WriteLine($"{e.ChangeType}\t{e.FullPath}");
    }

    public static void OnChanged(object source, FileSystemEventArgs e)
    {
        DateTime time = DateTime.Now;

        if (log.ContainsKey(time))
        {
            log[time] = e;
        }
        else
        {
            log.Add(time, e);
        }

        Console.WriteLine($"{e.ChangeType}\t{e.FullPath}");
        Thread.Sleep(COPY_DELAY);
        File.Copy(e.FullPath, Path.Combine(backupPath, Hash(time, e).ToString()));
    }

    public static long Hash(DateTime time, FileSystemEventArgs e)
    {
        return ((long)time.GetHashCode() << 32) | (long)e.GetHashCode();
    }

    public static void SaveLog()
    {
        StreamWriter logWriter = new StreamWriter(Path.Combine(backupPath, LOG_FILENAME));

        foreach (var point in log)
        {
            logWriter.WriteLine(point.Key.ToBinary());
            logWriter.WriteLine((byte)point.Value.ChangeType);
            logWriter.WriteLine(point.Value.FullPath);
        }

        logWriter.Close();
    }
        
    public static void LoadLog()
    {
        log = new Dictionary<DateTime, FileSystemEventArgs>();
        StreamReader logReader = new StreamReader(Path.Combine(backupPath, LOG_FILENAME));
        string time, fullPath;
        WatcherChangeTypes wct;

        while (!string.IsNullOrEmpty(time = logReader.ReadLine()))
        {
            wct = (WatcherChangeTypes)byte.Parse(logReader.ReadLine());
            fullPath = logReader.ReadLine();
            log.Add(DateTime.FromBinary(long.Parse(time)), new FileSystemEventArgs(wct, Path.GetDirectoryName(fullPath), Path.GetFileName(fullPath)));
        }
                
        logReader.Close();
    }

    public static void Restore()
    {
        try
        {
            LoadLog();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Log file not found.");
            return;
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Warning! Failed to load the log file! Reason: {exc.Message}");
            return;
        }

        Console.WriteLine("Please enter the date and time to recover to:");
        DateTime recover;

        if (!DateTime.TryParse(Console.ReadLine(), out recover))
        {
            Console.WriteLine("Sorry, falied to read the date.");
            return;
        }

        logSorted = new SortedList<DateTime, FileSystemEventArgs>(log);
        var keys = logSorted.Keys;
        for (int i = keys.Count - 1; i >= 0 && keys[i] > recover; i--)
        {
            Undo(keys[i], logSorted[keys[i]]);
        }

        Console.WriteLine("Recover complete!");
    }

    public static void Undo(DateTime time, FileSystemEventArgs e)
    {
        switch (e.ChangeType)
        {
            case WatcherChangeTypes.Created:
                UndoCreate(e);
                break;
            case WatcherChangeTypes.Deleted:
                UndoDelete(time, e);
                break;
            case WatcherChangeTypes.Changed:
                UndoChange(time, e);
                break;
        }
    }

    public static void UndoCreate(FileSystemEventArgs e)
    {
        File.Delete(e.FullPath);
    }

    public static void UndoDelete(DateTime time, FileSystemEventArgs e)
    {
        string fileName = Hash(time, e).ToString();
        File.Copy(Path.Combine(backupPath, fileName), e.FullPath);
    }

    public static void UndoChange(DateTime time, FileSystemEventArgs e)
    {
        string fileName = Hash(time, e).ToString();
        File.Copy(Path.Combine(backupPath, fileName), e.FullPath);
    }
}