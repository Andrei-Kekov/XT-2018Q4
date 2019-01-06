using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

public static class Program
{
    public const string WATCH_PARAMETER = "/w";
    public const string RESTORE_PARAMETER = "/r";
    public const string EXIT_KEY = "q";
    public const string BACKUP_FOLDER_NAME = "Backup";
    public const string LOG_FILENAME = "log";
    private const int COPY_DELAY = 100;
    private static string backupPath;
    private static string watchPath;
    private static DirectoryInfo backupFolder;
    private static SortedList<DateTime, LogEntry> log;
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
        backupFolder = new DirectoryInfo(backupPath);

        if (args[0].Equals(WATCH_PARAMETER))
        {
            if (!Directory.Exists(watchPath))
            {
                Console.WriteLine("The directory you specified doesn't exist.");
                return;
            }

            Watch();
        }
        else if (args[0].Equals(RESTORE_PARAMETER))
        {
            if (!Directory.Exists(watchPath))
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
            Console.WriteLine("Log file not found. New log file will be created.");
            log = new SortedList<DateTime, LogEntry>();
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Warning! Failed to load the log file! Reason: {exc.Message}");
            log = new SortedList<DateTime, LogEntry>();
        }

        if (!backupFolder.Exists)
        {
            backupFolder.Create();
        }        

        watcher = new FileSystemWatcher(watchPath, "*.txt");
        watcher.IncludeSubdirectories = true;
        watcher.Created += new FileSystemEventHandler(OnCreated);
        watcher.Deleted += new FileSystemEventHandler(OnDeleted);
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.EnableRaisingEvents = true;
        Console.WriteLine($"Watching the directory: {watchPath}");
        Console.WriteLine("Press 'q' to exit.");

        while (Console.ReadLine() != EXIT_KEY)
        {
        }

        SaveLog();
    }

    public static void LoadLog()
    {
        Stream load = File.OpenRead(Path.Combine(backupPath, LOG_FILENAME));
        BinaryFormatter formatter = new BinaryFormatter();
        log = (SortedList<DateTime, LogEntry>)formatter.Deserialize(load);
        load.Close();
    }

    public static void SaveLog()
    {
        Stream save = File.OpenWrite(Path.Combine(backupPath, LOG_FILENAME));
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(save, log);
        save.Close();
    }

    public static void OnCreated(object source, FileSystemEventArgs e)
    {
        DateTime time = DateTime.Now;
        Console.WriteLine($"{e.ChangeType}\t{e.FullPath}");
        Thread.Sleep(COPY_DELAY);
        string backupFile = Path.Combine(backupPath, Hash(time, e).ToString());
        File.Copy(e.FullPath, backupFile);

        if (log.ContainsKey(time))
        {
            log[time] = new LogEntry(e.ChangeType, e.FullPath, backupFile);
        }
        else
        {
            log.Add(time, new LogEntry(e.ChangeType, e.FullPath, backupFile));
        }
    }

    public static void OnDeleted(object source, FileSystemEventArgs e)
    {
        DateTime time = DateTime.Now;
        Console.WriteLine($"{e.ChangeType}\t{e.FullPath}");

        if (log.ContainsKey(time))
        {
            log[time] = new LogEntry(e.ChangeType, e.FullPath, string.Empty);
        }
        else
        {
            log.Add(time, new LogEntry(e.ChangeType, e.FullPath, string.Empty));
        }        
    }

    public static void OnChanged(object source, FileSystemEventArgs e)
    {
        DateTime time = DateTime.Now;
        Console.WriteLine($"{e.ChangeType}\t{e.FullPath}");
        Thread.Sleep(COPY_DELAY);
        string backupFile = Path.Combine(backupPath, Hash(time, e).ToString());
        File.Copy(e.FullPath, backupFile);

        if (log.ContainsKey(time))
        {
            log[time] = new LogEntry(e.ChangeType, e.FullPath, backupFile);
        }
        else
        {
            log.Add(time, new LogEntry(e.ChangeType, e.FullPath, backupFile));
        }
    }

    public static long Hash(DateTime time, FileSystemEventArgs e)
    {
        return ((long)time.GetHashCode() << 32) | (long)e.GetHashCode();
    }

    public static void Restore()
    {
        DateTime currentVersion = DateTime.Now;

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

        string input;
        DateTime recover;

        while (true)
        {
            Console.WriteLine("Please enter the date and time to recover to, or 'q' to exit:");
            input = Console.ReadLine();

            if (input == EXIT_KEY)
            {
                break;
            }            

            if (!DateTime.TryParse(input, out recover))
            {
                Console.WriteLine("Sorry, failed to read the date.");
                continue;
            }

            if (recover < currentVersion)
            {
                for (int i = log.Count - 1; i >= 0 && log.ElementAt(i).Key > recover; i--)
                {
                    Undo(log.ElementAt(i));
                }
            }

            if (recover > currentVersion)
            {
                for (int i = log.IndexOfKey(currentVersion) + 1; i < log.Count && log.ElementAt(i).Key < recover; i++)
                {
                    Redo(log.ElementAt(i));
                }
            }

            currentVersion = recover;
            Console.WriteLine("Recovery complete!");
        }
    }

    private static void Undo(KeyValuePair<DateTime, LogEntry> entry)
    {
        switch (entry.Value.Type)
        {
            case WatcherChangeTypes.Created:
                File.Delete(entry.Value.Path);
                break;
            case WatcherChangeTypes.Deleted:
                File.Copy(LastBackup(entry.Value.Path, entry.Key), entry.Value.Path);
                break;
            case WatcherChangeTypes.Changed:
                File.Copy(LastBackup(entry.Value.Path, entry.Key), entry.Value.Path, true);
                break;
        }
    }

    private static void Redo(KeyValuePair<DateTime, LogEntry> entry)
    {
        switch (entry.Value.Type)
        {
            case WatcherChangeTypes.Created:
                File.Copy(entry.Value.BackupPath, entry.Value.Path);
                break;
            case WatcherChangeTypes.Deleted:
                File.Delete(entry.Value.Path);
                break;
            case WatcherChangeTypes.Changed:
                File.Copy(entry.Value.BackupPath, entry.Value.Path, true);
                break;
        }
    }

    private static string LastBackup(string path, DateTime recover)
    {
        int i = log.IndexOfKey(recover) - 1;

        while (i > 0 && log.ElementAt(i).Value.Path != path)
        {
            i--;
        }

        return log.ElementAt(i).Value.BackupPath;
    }
}