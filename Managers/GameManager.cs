using customfinal.Common;
using customfinal.ConcreteClasses;
using customfinal.ConcreteClasses.PowerUps;
using SplashKitSDK;
using Barrier = customfinal.ConcreteClasses.Barrier;

namespace customfinal.Managers
{
    public class GameManager
    {
        private FireballManager _fireballManager = new FireballManager();
        private EnemyManager _enemyManager = new EnemyManager();
        private BarrierManager _barrierManager = new BarrierManager();
        private PowerUpManager _powerUpManager = new PowerUpManager();

        private static readonly GameManager instance = new GameManager();


        private Player? _player;

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
        public PowerUpManager PowerUpManager { get => _powerUpManager; set => _powerUpManager = value; }
        public void LoadAllBitmaps()
        {
            SplashKit.LoadBitmap("Player", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Player.png");
            SplashKit.LoadBitmap("Enemy", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Enemy.png");
            SplashKit.LoadBitmap("Fireball", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Fireball.png");
            SplashKit.LoadBitmap("Barrier", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Barrier.png");
            SplashKit.LoadBitmap("PowerUpHeal", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\HP_icon.png");
            SplashKit.LoadBitmap("PowerUpSpeed", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Spd icon.png");
            SplashKit.LoadBitmap("PowerUpDamage", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Dmg icon.png");
        }
        public void MoveAll()
        {
            _player.Move();
            _enemyManager.MoveAllEnemies();
            _fireballManager.MoveAllFireballs();
            
        }

        public void Update()
        {
            PlayerInputCheck();
            MoveAll();
            CollisionCheck();
            ClearAllDestroyedObjects();
            DrawAll();
            EnemyManager.SpawnMore();
            PowerUpManager.SpawnMore();
            BarrierManager.SpawnMore();
        }

        private void ClearAllDestroyedObjects()
        {
            _enemyManager.ClearAllDestroyedEnemies();
            _fireballManager.ClearAllDestroyedFireballs();
            _barrierManager.ClearAllDestroyedBarriers();
            _powerUpManager.ClearAllDestroyedPowerUps();
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
            _barrierManager.DrawAllBarriers();
            _powerUpManager.DrawAllPowerUps();
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
            foreach (Enemy enemy in _enemyManager.Enemies)
            {
                if (CheckCollision(enemy, _player))
                {
                    _player.Hurt(enemy.Damage);
                    enemy.DestroySelf();
                }
            }
            foreach (Barrier barrier in _barrierManager.Barriers)
            {
                foreach (Fireball fireball in _fireballManager.Fireballs)
                {
                    if (CheckCollision(barrier, fireball))
                    {
                        barrier.Hurt(fireball.Damage);
                        fireball.DestroySelf();
                    }
                }
            }
            foreach (PowerUp powerUp in _powerUpManager.PowerUps)
            {
                if (CheckCollision(powerUp, _player))
                {
                    powerUp.ApplyPowerUp(_player);
                    powerUp.DestroySelf();
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

        //check to see if the x y position is a valid position for the player to move to
        public bool PlayerAllowedToMoveTo(float x, float y)
        {
            bool allowed = true;
            foreach(Barrier barrier in _barrierManager.Barriers)
            {
                allowed = !SplashKit.BitmapCollision(_player.Bitmap, x, y, barrier.Bitmap, barrier.X, barrier.Y);
                if (allowed == false)
                {
                    break;
                }
            }
            return allowed;
        }
        public void GameOver()
        {
            SplashKit.ClearScreen();
            SplashKit.DrawText("Game Over", Color.Black, Constants.GameWindow.Width / 2 - 50, Constants.GameWindow.Height / 2);
            SplashKit.DrawText("Press space to play again", Color.Black, Constants.GameWindow.Width / 2 - 50, Constants.GameWindow.Height / 2 + 200);
            SplashKit.RefreshScreen();
        }

        public void Restart()
        {
            _player = null;
            _enemyManager.ClearAllEnemies();
            _fireballManager.ClearAllFireballs();
            _barrierManager.ClearAllBarriers();
            _powerUpManager.ClearAllPowerUps();
            GameStart();
        }

        public void GameStart()
        {
            SpawnPlayer(Constants.GameWindow.Width / 2, Constants.GameWindow.Height / 2, 5, 5, 100);
            int enemiesToSpawn = 3;
            while (enemiesToSpawn > 0)
            {
                EnemyManager.SpawnEnemyRandomPos();

                enemiesToSpawn--;
            }

            int barriersToSpawn = 3;
            while (barriersToSpawn > 0)
            {
                BarrierManager.SpawnBarrierRandomPos();

                barriersToSpawn--;
            }
            int powerUpsToSpawn = 3;
            while (powerUpsToSpawn > 0)
            {
                PowerUpManager.SpawnPowerUpRandomPos();
                powerUpsToSpawn--;
            }
        }
    }
    
}
