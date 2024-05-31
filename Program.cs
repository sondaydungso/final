using System;
using SplashKitSDK;

namespace customfinal
{
    public class Program
    {
        public static void Main()
        {
            new Window("Game", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                SplashKit.RefreshScreen();
            }while (!SplashKit.WindowCloseRequested("Game"));
        }
    }
}
