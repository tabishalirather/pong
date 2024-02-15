using SplashKitSDK;

public class Bat
{
    public  int x_bat { get; set; }
    public int y_bat { get; set; }
    public int width_bat { get; set; }
    public int height_bat { get; set; }

    public Bat(int y, int width,int height)
    {
        width_bat = width/30;
        height_bat = height/5;
        y_bat = y + (height - height_bat)/2;
    }
    public Bat(int x,int y, int width,int height)
    {
        width_bat = width/30;
        x_bat = width - width_bat;
        height_bat = height/5;
        y_bat = y + (height - height_bat)/2;
    }
    public void CheckMove(int height, KeyCode moveUpKey, KeyCode moveDownKey)
    {
        if(SplashKit.KeyTyped(moveUpKey) || SplashKit.KeyDown(moveUpKey))
        {
            MoveUp();
        }
        else if(SplashKit.KeyTyped(moveDownKey) || SplashKit.KeyDown(moveDownKey))
        {
            MoveDown(height);
        }
    }
    public void MoveUp()
    {
        
        if(y_bat > 0)
        {
            y_bat -= 5;
        }
    }

    public void MoveDown(int height)
    {
        if(y_bat < height - height_bat)
        {
            y_bat += 5;
        }
    }

    public void DrawBat(Color color)
    {
        SplashKit.FillRectangle(color, x_bat, y_bat, width_bat, height_bat);
    }
}