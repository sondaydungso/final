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
        private Bitmap _bitmap;
        private float _speed;
        private HeathPool _healthPool;
        public Enemy(string name, Bitmap bitmap, float x, float y, float speed, HeathPool healthPool) : base(name, bitmap, x, y)
        {
            _speed = speed;
            _healthPool = healthPool;
            _bitmap = SplashKit.BitmapNamed("");// Add this after finish
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, X, Y);
        }
        public override void DestroySelf()
        {
            SplashKit.FreeBitmap(_bitmap);
        }
        public void Move()
        {
            var playerX = MovementManager.Player.X;
            var playerY = MovementManager.Player.Y;

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

        public HeathPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }

        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
    }
}
