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
            GameManager.Instance.LoadAllBitmaps();
            GameManager.Instance.GameStart();
        }

        public static void Main()
        {
            new Window("My Game", Constants.GameWindow.Width, Constants.GameWindow.Height);

            Setup();
            bool gameover = false;
            do
            {
                SplashKit.ProcessEvents();
                //process a game frame
                if (!gameover)
                {
                    SplashKit.ClearScreen();
                    GameManager.Instance.Update();
                }
                if (GameManager.Instance.Player.HealthPool.CurrentHealth <= 0 && !gameover)
                {
                    gameover = true;
                    GameManager.Instance.GameOver();
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && gameover)
                {
                    GameManager.Instance.Restart();
                    gameover = false;
                }

                //refresh with a 60fps cap
                SplashKit.RefreshScreen(60);
            }while (!SplashKit.WindowCloseRequested("My Game"));
        }
    }

}
