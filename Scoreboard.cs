using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customfinal
{
    public class Scoreboard
    {
        private int _time;
        private int _levelId;
        private HealthPool _playerHealth;
        private ulong _times;
        public Scoreboard(int time, int levelId, HealthPool playerHealth)
        {
            Time = time;
            LevelId = levelId;
            PlayerHealth = playerHealth;
        }
        public void Draw()
        {
            SplashKit.DrawText("Time: " + Time, Color.Black, 10, 10);
            SplashKit.DrawText("Level: " + LevelId, Color.Black, 10, 30);
            SplashKit.DrawText("Health: " + PlayerHealth.CurrentHealth, Color.Black, 10, 50);
        }
        public void UpdateTime()
        {
            ulong currentTime = SplashKit.CurrentTicks() - _times;
            Time = (int)currentTime / 1000;
        }
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public int LevelId
        {
            get { return _levelId; }
            set { _levelId = value; }
        }
        public HealthPool PlayerHealth
        {
            get { return _playerHealth; }
            set { _playerHealth = value; }
        }
    }
}
