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

                Player player = new Player("Player", SplashKit.BitmapNamed("Player"), 400, 300, 5, new HealthPool(1, 1));
                MovementManager.Player = player;

                //spawn enemies
                int enemiesToSpawn = 10;
                while(enemiesToSpawn > 0)
                {
                    Enemy enemy = new Enemy("Enemy", SplashKit.BitmapNamed("Enemy"), 100, 100, 2, new HealthPool(1, 1));
                    //register enemy as a moveable, and will be moved by the movement manager
                    enemy.RegisterAsMoveable();
                    enemiesToSpawn--;
                }
                PowerUp powerUp = new PowerUpMovementSpeed("PowerUpSpeed", SplashKit.BitmapNamed("PowerUp"), 200, 200, 3, 5);
                PowerUp powerUp1 = new PowerUpHeal("PowerUpHeal", SplashKit.BitmapNamed("PowerUp"), 200, 200, 3);

                //Move everything that can move
                MovementManager.MoveAll();

                SplashKit.RefreshScreen();
            }while (!SplashKit.WindowCloseRequested("Game"));
        }
    }
}
