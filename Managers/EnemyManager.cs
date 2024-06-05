using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.Managers
{
    public class EnemyManager
    {
        private int _enemyDamage = 1;
        private float _enemySpeed = 2f;
        private int _enemyMaxHp = 10;

        private List<Enemy> _enemies = new List<Enemy>();

        public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }

        public EnemyManager()
        {
        }
        //spawn enemy at random position
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

        //kill off everything to restart the game
        public void ClearAllEnemies()
        {
            _enemies.Clear();
        }

        //delete all enemies that are destroyed
        public void ClearAllDestroyedEnemies()
        {
            _enemies.RemoveAll(enemy => enemy.IsDestroyed);
        }

        //draw all enemies
        public void DrawAllEnemies()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Draw();
            }
        }

        //move all enemies
        public void MoveAllEnemies()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Move();
            }
        }

        //spawn more enemies
        public void SpawnMore()
        {
            Random random = new Random();
            int spawnrate = random.Next(0, 50);
            if (Enemies.Count == 0)
            {
                for (int i = 0; i < spawnrate; i++)
                {
                    SpawnEnemyRandomPos();
                }
            }
        }

        //kill an enemy
        public void KillEnemy(Enemy enemy)
        {
            enemy.IsDestroyed = true;
        }

        
    }
}
