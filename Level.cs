using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customfinal
{
    public class Level
    {
        private List<Barrier> barrierList;
        private List<Enemy> enemyList;
        private int _levelNumber;
        public Level()
        {
            _levelNumber = LevelNumber;
            barrierList = new List<Barrier>();
            enemyList = new List<Enemy>();
        }
        public int LevelNumber
        {
            get { return _levelNumber; }
            set { _levelNumber = value; }
        }
        public void Draw()
        {
            foreach (Barrier barrier in barrierList)
            {
                barrier.Draw();
            }
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw();
            }
        }
        public void Update()
        {
           MovementManager.MoveAll();
        }
        public void AddBarrier(Barrier barrier)
        {
            Barrier barrier1 = new Barrier("Barrier", SplashKit.BitmapNamed("Barrier"), 100, 100, new HealthPool(9999999,100));
            barrierList.Add(barrier);
        }
    }
}
