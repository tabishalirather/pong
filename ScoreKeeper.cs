namespace pong;
using SplashKitSDK;

public class Score()
{
    public int score_left = 0;
    public int score_right = 0;
    public void UpdateScore(string side)
    {
        // DrawScore();
        // DrawScore(score_left, score_right);
        if(side == "left")
        {
            score_left++;
            Console.WriteLine($"{side} player socre is: {score_left}");
            SplashKit.RefreshScreen(60);
        }
        else
        {
            score_right++;
            Console.WriteLine($"{side} player socre is: {score_right}");
        }
    }
    public  void  DrawScore()
    {
        // Console.WriteLine("I am gettinc invoked");
        SplashKit.DrawText($"Score: {score_left.ToString()}", Color.White, "arial", 50, 50, 50);
        SplashKit.DrawText($"Score: {score_right.ToString()}", Color.White, "arial", 50, 700, 50);
        
        Console.WriteLine($"Score in DrawScore is {score_left} and {score_right}");
        SplashKit.RefreshScreen(60);
    }
    
}