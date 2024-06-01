using customfinal.Common;
using customfinal.Interfaces;
using customfinal.Managers;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal.ConcreteClasses
{
    public class Enemy : GameObject, IMoveable
    {
        private bool _isDestroyed = false;
        private float _speed;
        private HealthPool _healthPool;
        private int _damage;
        public Enemy(string name, Bitmap bitmap, float x, float y, float speed, int damage, int maxHp) : base(name, bitmap, x, y)
        {
            _speed = speed;
            _healthPool = new HealthPool(maxHp, maxHp);
            _damage = damage;
        }
        public override void Draw()
        {
            if (!IsDestroyed)
            {
                SplashKit.DrawBitmap(Bitmap, X, Y);
            }
        }
        public override void DestroySelf()
        {
            GameManager.Instance.EnemyManager.KillEnemy(this);
        }
        public void Move()
        {
            var playerX = GameManager.Instance.Player.X;
            var playerY = GameManager.Instance.Player.Y;

            // Calculate the direction towards the player
            float deltaX = (float)(playerX - X);
            float deltaY = (float)(playerY - Y);

            // Normalize the direction vector
            float distance = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);
            if (distance == 0)
            {
                return;
            }
            float directionX = deltaX / distance;
            float directionY = deltaY / distance;

            // Adjust the enemy's position based on the direction and speed
            X += directionX * _speed;
            Y += directionY * _speed;
        }

        public void Hurt(int damage)
        {
            HealthPool.TakeDamage(damage);
            if (HealthPool.CurrentHealth <= 0)
            {
                DestroySelf();
            }
        }

        public HealthPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }

        public bool IsDestroyed { get => _isDestroyed; set => _isDestroyed = value; }
    }
}
