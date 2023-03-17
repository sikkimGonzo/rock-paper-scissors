using Models;

public class Program
{
    public static void Main(string[] args)
    {
        ChoosOption(args);
    }

    public static void ChoosOption(string[] args)
    {
        bool isEven = args.Length % 2 == 0;
        bool isRepeated = args.Length != args.Distinct().Count();
        

        if(args.Length < 3)
        {
            Console.WriteLine("You must enter at least three arguments");
        }
        else if(isEven && !isRepeated)
        {
            Console.WriteLine("The number of arguments must be odd");
        }
        else if(!isEven && isRepeated)
        {
            Console.WriteLine("The arguments must not be repeated");
        }
        else if(isEven && isRepeated)
        {
            Console.WriteLine("The arguments must not be repeated and the number of them must be odd");
        }
        else
        {
            GetDefaultOption(args);
        }

        Console.WriteLine();
    }

    public static void GetDefaultOption(string[] args)
    {
        int computerMove = RandomNumberGenerator.GetInt32(args.Length);
        string computerMoveData = args[computerMove];
        byte[] key = MoveCryptography.GetKeySHA256(32);
        byte[] hmac = MoveCryptography.GetHMAC(key, computerMoveData);
        Console.WriteLine("hmac: {0}", Convert.ToHexString(hmac));
        PrintMenu(args);
        int userMove = ReadUserMove(args) - 1;
        GetMoveData(computerMove, userMove, key, args);
    }

    public static void GetMoveData(int computerMove, int userMove, byte[] key, string[] args)
    {
        string RockPaperScissorsResult = RockPaperScissorsGame.GetResult(computerMove, userMove, args);
        Console.WriteLine("Your move: {0}", args[userMove]);
        Console.WriteLine("Computer move: {0}", args[computerMove]);
        Console.WriteLine(RockPaperScissorsResult == "Draw" ? RockPaperScissorsResult : $"You {RockPaperScissorsResult}!");
        Console.WriteLine("hmac key: {0}", Convert.ToHexString(key));
    }

    public static void PrintMenu(string[] args)
    {
        for(int i = 0; i < args.Length; ++i)
        {
            Console.WriteLine("{0} - {1}", i + 1, args[i]);
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
        Console.Write("Enter your move: ");
    }

    public static int ReadUserMove(string[] args)
    {
        string? userMove = Console.ReadLine();
        int res = 0;
        while(true)
        {
            if(userMove == "0")
            {
                Environment.Exit(0);
            }
            else if(userMove == "?")
            {
                var table = HelpInfo.GetHelpInfo(args);
                table.Write();
                Console.Write("Enter your move: ");
                userMove = Console.ReadLine();
            }
            else if(int.TryParse(userMove, out int number) && number <= args.Length)
            {
                res = number;
                break;
            }
            else
            {
                Console.WriteLine("Сhoose an option from the menu: ");
                PrintMenu(args);
                userMove = Console.ReadLine();
            }
        }
        return res;
    }
}