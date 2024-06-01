using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.Managers
{
    public class EnemyManager
    {
        private int _enemyDamage = 1;
        private float _enemySpeed = 2f;
        private int _enemyMaxHp = 1;

        private List<Enemy> _enemies = new List<Enemy>();

        public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }

        public EnemyManager()
        {
        }

        public void SpawnEnemyRandomPos()
        {
            Enemy enemy = new Enemy("enemy", SplashKit.BitmapNamed("Enemy"), SplashKit.Rnd(0, 800), SplashKit.Rnd(0, 600), _enemySpeed, _enemyDamage, _enemyMaxHp);
            _enemies.Add(enemy);
        }

        public void SpawnEnemy(float x, float y)
        {
            Enemy enemy = new Enemy("enemy", SplashKit.BitmapNamed("Enemy"), x, y, _enemySpeed, _enemyDamage, _enemyMaxHp);
            _enemies.Add(enemy);
        }

        //kill off everything and de-reference it from GameManager so that garbage collection can do the cleaning
        public void ClearAllEnemies()
        {
            _enemies.Clear();
        }

        public void ClearAllDestroyedEnemies()
        {
            _enemies.RemoveAll(enemy => enemy.IsDestroyed);
        }

        public void DrawAllEnemies()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Draw();
            }
        }
        public void MoveAllEnemies()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Move();
            }
        }

        public void KillEnemy(Enemy enemy)
        {
            enemy.IsDestroyed = true;
        }

        public void ClearEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }
    }
}
