using System.Text.RegularExpressions;

public class CommandLine
{
    private readonly string fileName;
    private readonly bool Start;
    private readonly bool StartTimestamp;
    private readonly bool AutoClose;
    public CommandLine(string[] cmds)
    {
        fileName = "config.ini";
        Start = false;
        StartTimestamp = false;
        AutoClose = false;
        foreach (string cmd in cmds)
        {
            if (Regex.IsMatch(cmd, @"^/ini\s+(\S+\.ini)$"))
            {
                Match match = Regex.Match(cmd, @"\s(\S+\.ini)");
                this.fileName = match.Groups[1].Value;
            }
            if (cmd == @"/Start") this.Start = true;
            if (cmd == @"/StartTimestamp") this.StartTimestamp = true;
            if (cmd == @"/AutoClose") this.AutoClose = true;
        }
    }
    public string GetFileName()
    {
        return this.fileName;
    }
    public bool IsStart()
    {
        return this.Start;
    }
    public bool IsStartTimestampe()
    {
        return this.StartTimestamp;
    }
    public bool IsAutoClose()
    {
        return this.AutoClose;
    }
}
