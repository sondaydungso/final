using customfinal.Managers;
using SplashKitSDK;

namespace customfinal.ConcreteClasses
{
    public class Level
    {
        private List<Point2D> _barriersPos = new List<Point2D>();
        private List<Point2D> _enemiesPos = new List<Point2D>();
        private int _levelNumber;

        public Level(List<Point2D> barriers, List<Point2D> enemies)
        {
            _levelNumber = LevelNumber;
            _barriersPos = barriers;
            _enemiesPos = enemies;
        }
        public int LevelNumber
        {
            get { return _levelNumber; }
            set { _levelNumber = value; }
        }

        public List<Point2D> BarriersPos { get => _barriersPos; set => _barriersPos = value; }
        public List<Point2D> EnemiesPos { get => _enemiesPos; set => _enemiesPos = value; }

        public void LoadLevel()
        {
            //spawn barriers
            foreach (Point2D barrier in _barriersPos)
            {
                //TODO: implement barrier manager
                //GameManager.Instance.BarrierManager.SpawnBarrier(barrier.X, barrier.Y);
            }

            //spawn enemies
            foreach (Point2D enemy in _enemiesPos)
            {
                GameManager.Instance.EnemyManager.SpawnEnemy((float)enemy.X, (float)enemy.Y);
            }
        }
    }
}
