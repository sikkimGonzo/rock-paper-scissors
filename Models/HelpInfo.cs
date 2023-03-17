namespace Models;

public class HelpInfo
{
    public static ConsoleTable GetHelpInfo(string[] args)
    {
        List<string> arguments = args.ToList();
        ConsoleTable table = new ConsoleTable();
        List<string> columns = new List<string>();
        columns.Add("");
        foreach(var i in args)
        {
            columns.Add(i);
        }
        table.AddColumn(columns);
        foreach(string i in arguments)
        {
            List<string> rows = new List<string>();
            rows.Add(i);
            foreach(string j in arguments)
            {
                rows.Add(RockPaperScissorsGame.GetResult(arguments.IndexOf(j), arguments.IndexOf(i), args));
            }
            table.AddRow(rows.ToArray());
        }
        return table;
    }
}
