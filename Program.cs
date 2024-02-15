using SplashKitSDK;

namespace pong;

public class Program
{
    public static void Main()
    {
        int width = 800;
        int height = 600;
        // int x_left = 0;
        int y_left = 0;
        Window w = new("Pong", 800, 600);
        // w.Clear(Color.Black);
        Bat b_left = new(y_left, width, height);
        int x_right = width - 50;
        int y_right = 0;
        Bat b_right = new (x_right, y_right, width, height);

        int x_intial_ball = 0;
        int y_intial_ball = 0;
        Ball ball = new (x_intial_ball, y_intial_ball, width, height, b_right, b_left);
        while (!w.CloseRequested)
        {
            SplashKit.ProcessEvents();
            w.Clear(Color.Black);
            b_left.DrawBat(Color.White);
            b_right.DrawBat(Color.White);
            b_left.CheckMove(height, KeyCode.WKey, KeyCode.SKey);
            b_right.CheckMove(height, KeyCode.UpKey, KeyCode.DownKey);
            ball.DrawBall(Color.Green);
            ball.MoveBall(width, height, b_left, b_right);
            ball.score_keeper.DrawScore();
            w.Refresh();
            // SplashKit.RefreshScreen(60);
        }
    }

}