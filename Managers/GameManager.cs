using customfinal.Common;
using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.Managers
{
    public class GameManager
    {
        private FireballManager _fireballManager = new FireballManager();
        private EnemyManager _enemyManager = new EnemyManager();
        private BarrierManager _barrierManager = new BarrierManager();

        private static readonly GameManager instance = new GameManager();


        private Player _player;

        static GameManager()
        {
        }

        private GameManager()
        {
        }

        public static GameManager Instance
        {
            get
            {
                return instance;
            }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public FireballManager FireballManager { get => _fireballManager; set => _fireballManager = value; }
        public EnemyManager EnemyManager { get => _enemyManager; set => _enemyManager = value; }
        public BarrierManager BarrierManager { get => _barrierManager; set => _barrierManager = value; }

        public void MoveAll()
        {
            _player.Move();
            _enemyManager.MoveAllEnemies();
            _fireballManager.MoveAllFireballs();
            _barrierManager.DrawAllBarriers();
        }

        public void Update()
        {
            PlayerInputCheck();
            MoveAll();
            CollisionCheck();
            ClearAllDestroyedObjects();
            DrawAll();
        }

        private void ClearAllDestroyedObjects()
        {
            _enemyManager.ClearAllDestroyedEnemies();
            _fireballManager.ClearAllDestroyedFireballs();
        }

        public void PlayerInputCheck()
        {
            //only checks shooting, not moving because Player class already takes care of moving inputs with Player.Move()
            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                _player.Shoot();
            }
        }

        private void DrawAll()
        {
            if (_player != null)
            {
                _player.Draw();
            }
            _enemyManager.DrawAllEnemies();
            _fireballManager.DrawAllFireballs();
        }

        private void CollisionCheck()
        {
            foreach (Enemy enemy in _enemyManager.Enemies)
            {
                foreach (Fireball fireball in _fireballManager.Fireballs)
                {
                    if (CheckCollision(enemy, fireball))
                    {
                        enemy.Hurt(fireball.Damage);
                        fireball.DestroySelf();
                    }
                }
            }
        }

        private bool CheckCollision(GameObject obj1, GameObject obj2)
        {
            return SplashKit.BitmapCollision(obj1.Bitmap, obj1.X, obj1.Y, obj2.Bitmap, obj2.X, obj2.Y);
        }

        public void SpawnPlayer(float x, float y, float speed, int damage, int maxHp)
        {
            _player = new Player("Player", SplashKit.BitmapNamed("Player"), x, y, speed, damage, maxHp);
        }
    }
}
