using System;
using SplashKitSDK;

namespace customfinal
{
    public class Program
    {
        private static void Setup()
        {
            Player player = new Player("Player", SplashKit.LoadBitmap("Player", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Player.png"), 400, 300, 1, 10, new HealthPool(5, 5));

            //add player to the list of game objects to be drawn
            GameManager.AddGameObject(player);
            GameManager.AddMoveable(player);
            GameManager.Player = player;
            
            

            //spawn enemies
            int enemiesToSpawn = 1;
            while (enemiesToSpawn > 0)
            {
                Enemy enemy = new Enemy("Enemy", SplashKit.LoadBitmap("Enemy", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Enemy.png"), 100, 100, 0.1f, 5, new HealthPool(1, 1));
                //register enemy as a moveable, and will be moved by the movement manager
                enemy.RegisterAsMoveable();

                //add enemy to the list of game objects to be drawn
                GameManager.AddGameObject(enemy);

                enemiesToSpawn--;
            }
            //PowerUp powerUp = new PowerUpMovementSpeed("PowerUpSpeed", SplashKit.BitmapNamed("PowerUp"), 200, 200, 3, 5);
            //PowerUp powerUp1 = new PowerUpHeal("PowerUpHeal", SplashKit.BitmapNamed("PowerUp"), 200, 200, 3);

        }

        public static void Main()
        {
            new Window("Game", 800, 600);

            Setup();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                //player shoot input check
                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    GameManager.Player.Shoot();
                }

                //Move everything that can move
                GameManager.MoveAll();

                //draw everything
                GameManager.Update();

                SplashKit.RefreshScreen(60);
            }while (!SplashKit.WindowCloseRequested("Game"));
        }
    }

}
