using System;
using System.IO;

[Serializable]
public class LogEntry
{
    public LogEntry(WatcherChangeTypes type, string path, string backupPath)
    {
        this.Type = type;
        this.Path = path;

        if (type != WatcherChangeTypes.Deleted)
        {
            this.BackupPath = backupPath;
        }
        else
        {
            this.BackupPath = string.Empty;
        }
    }

    public WatcherChangeTypes Type { get; private set; }

    public string Path { get; private set; }

    public string BackupPath { get; private set; }
}