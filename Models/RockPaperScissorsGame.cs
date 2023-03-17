namespace Models;

public class RockPaperScissorsGame
{
    public static string GetResult(int computerMove, int userMove, string[] args)
    {
        if(computerMove == userMove)
            return "Draw";
        int circleHalf = (args.Length - 1) / 2;
        var maxMoveNumber = Math.Max(computerMove, userMove);
        var minMoveNumber = Math.Min(computerMove, userMove);
        int result = maxMoveNumber - minMoveNumber > circleHalf ? maxMoveNumber : minMoveNumber;
        return result == userMove ? "Win" : "Lose";
    }
}