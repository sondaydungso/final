using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class Enemy : GameObject, IMoveable
    {
        private float _speed;
        private HealthPool _healthPool;
        private int _damage;
        public Enemy(string name, Bitmap bitmap, float x, float y, float speed, int damage, HealthPool healthPool) : base(name, bitmap, x, y)
        {
            _speed = speed;
            _healthPool = healthPool;
            _damage = damage;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
        }
        public override void DestroySelf()
        {
           
           
        }
        public void Move()
        {
            var playerX = GameManager.Player.X;
            var playerY = GameManager.Player.Y;

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
        public void RegisterAsMoveable()
        {
            GameManager.AddMoveable(this);
        }
        public void Hurt(int damage)
        {
            HealthPool.TakeDamage(damage);           
        }

        public HealthPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }

        
        
    }
}
