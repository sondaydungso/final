using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customfinal
{
    public class Fireball : GameObject, IMoveable, IHurtable
    {
       
        private float _speed;
        private float _directionX;
        private float _directionY;
        private float _mouseX;
        private float _mouseY;
        private float _playerX;
        private float _playerY;
        private HealthPool _healthPool;

        public Fireball(string name, Bitmap bitmap, float x, float y, float speed, float directionX, float directionY, HealthPool healthPool) : base(name, bitmap, x, y)
        {
            _speed = speed;
            _directionX = directionX;
            _directionY = directionY;
            _playerX = x;
            _playerY = y;
            _healthPool = healthPool;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
        }
        public override void DestroySelf()
        {
            SplashKit.FreeBitmap(Bitmap);
        }
        public void Move() 
        {
            float mouseX = SplashKit.MouseX();
            float mouseY = SplashKit.MouseY();
            float deltaX = mouseX - X;
            float deltaY = mouseY - Y;
            float distance = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);
            if (distance == 0)
            {
                return;
            }
            float directionX = deltaX / distance;
            float directionY = deltaY / distance;
            X += directionX * _speed;
            Y += directionY * _speed;
        }
        public void Hurt(int damage)
        {
            HealthPool.TakeDamage(damage);
        }
        public void RegisterAsMoveable()
        {
            MovementManager.AddMoveable(this);
        }
        public HealthPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }
        
    }
}
