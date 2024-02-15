using SplashKitSDK;

namespace pong;

public class Ball
{
    public int x_ball { get; set; }
    public int y_ball { get; set; }
    public int width_ball { get; set; }
    public int height_ball { get; set; }

    public int x_bat_right { get; set; }
    public int x_bat_left { get; set; }
    
    public int y_bat_right { get; set; }
    public int y_bat_left { get; set; }
    
    public int width_bat { get; set; }
    
    public Score score_keeper = new Score();
    public static int min_x_dir = -15;
    static int max_x_dir = 15;
    int x_direction = 12;
    int y_direction = 6;

    public Ball(int x, int y, int width, int height, Bat bat_right, Bat bat_left)

    {
        width_ball = width / 30;
        height_ball = height / 20;
        x_ball = x + (width / 2 - width_ball);
        y_ball = y + (height / 2 - height_ball);
        x_bat_right = bat_right.x_bat;
        x_bat_left = bat_left.x_bat;
        y_bat_right = bat_right.y_bat;
        y_bat_left = bat_left.y_bat;
        width_bat = bat_right.width_bat;
    }
    public void DrawBall(Color color)
    {
        SplashKit.FillRectangle(color, x_ball, y_ball, width_ball, height_ball);
    }
    public void MoveBall(int width, int height, Bat leftBat, Bat rightBat)
    {
        // Move the ball
        x_ball += x_direction;
        y_ball += y_direction;
        

        // Check for collision with top or bottom wall and reverse y direction if true
        if (y_ball <= 0 || y_ball >= height - height_ball)
        {
            y_direction *= -1;
        }

        // Check for collision with left or right wall to respawn the ball in the middle
        if (x_ball <= 0)
        {
            x_ball = width / 2 - width_ball / 2;
            y_ball = height / 2 - height_ball / 2;
            x_direction = SplashKit.Rnd(min_x_dir, max_x_dir);
            y_direction = SplashKit.Rnd(min_x_dir, max_x_dir);
            // Optionally, reset the ball's direction or give it a default direction
            // x_direction = initial_x_direction; // Define initial_x_direction as per your game's logic
            // y_direction = initial_y_direction; // Define initial_y_direction as per your game's logic
            score_keeper.UpdateScore("right");
            // score_keeper.DrawScore();
            // score_right++;
            // Console.WriteLine($"Right player score is: {score_right}");
        }

        if (x_ball >= width - width_ball)
        {
            x_ball = width / 2 - width_ball / 2;
            y_ball = height / 2 - height_ball / 2;
            x_direction = SplashKit.Rnd(min_x_dir, max_x_dir);
            y_direction = SplashKit.Rnd(min_x_dir, max_x_dir);
            score_keeper.UpdateScore("left");   
            // score_left++;
            // Console.WriteLine($"Left player score is: {score_left}");
        }

        // Check for collision with left bat and reverse x direction if true
        if (x_ball <= leftBat.x_bat + leftBat.width_bat &&
            x_ball + width_ball >= leftBat.x_bat &&
            y_ball + height_ball >= leftBat.y_bat &&
            y_ball <= leftBat.y_bat + leftBat.height_bat)
            // ScoreKeeper.score_left++;
            // score_keeper.DisplayScore();
        {
            x_direction *= -1;
        }

        // Check for collision with right bat and reverse x direction if true
        if (x_ball + width_ball >= rightBat.x_bat &&
            x_ball <= rightBat.x_bat + rightBat.width_bat &&
            y_ball + height_ball >= rightBat.y_bat &&
            y_ball <= rightBat.y_bat + rightBat.height_bat)
            // ScoreKeeper.score_right++;
        {
            x_direction *= -1;
        }
    }

}

