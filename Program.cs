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

                Player player = new Player("Player", SplashKit.BitmapNamed("Player"), 400, 300, 5, new HeathPool(100, 100));
                MovementManager.Player = player;

                //spawn enemies
                int enemiesToSpawn = 10;
                while(enemiesToSpawn > 0)
                {
                    Enemy enemy = new Enemy("Enemy", SplashKit.BitmapNamed("Enemy"), 100, 100, 2, new HeathPool(1, 1));
                    //register enemy as a moveable, and will be moved by the movement manager
                    MovementManager.AddMoveable(enemy);
                    enemiesToSpawn--;
                }


                //Move everything that can move
                MovementManager.MoveAll();

                SplashKit.RefreshScreen();
            }while (!SplashKit.WindowCloseRequested("Game"));
        }
    }
}
