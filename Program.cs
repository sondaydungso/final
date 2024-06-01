using System;
using customfinal.ConcreteClasses;
using customfinal.Managers;
using SplashKitSDK;

namespace customfinal
{
    public class Program
    {
        private static void Setup()
        {
            //setup bitmaps
            SplashKit.LoadBitmap("Player", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Player.png");
            SplashKit.LoadBitmap("Enemy", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Enemy.png");
            SplashKit.LoadBitmap("Fireball", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Fireball.png");

            //TODO: remove this dummy testing player
            GameManager.Instance.SpawnPlayer(400, 300, 3, 10, 5);

            //TODO: remove these dummy testing enemies
            int enemiesToSpawn = 3;
            while (enemiesToSpawn > 0)
            {
                GameManager.Instance.EnemyManager.SpawnEnemyRandomPos();
                enemiesToSpawn--;
            }
        }

        public static void Main()
        {
            new Window("Game", Constants.GameWindow.Width, Constants.GameWindow.Height);

            Setup();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                //process a game frame
                GameManager.Instance.Update();
                //refresh with a 60fps cap
                SplashKit.RefreshScreen(60);
            }while (!SplashKit.WindowCloseRequested("Game"));
        }
    }

}
