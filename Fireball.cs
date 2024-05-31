using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customfinal
{
    public class Fireball : GameObject, IMoveable
    {
       
        private float _speed;
        private float _directionX;
        private float _directionY;
        private float _mouseX;
        private float _mouseY;
        private float _playerX;
        private float _playerY;
        private HealthPool _healthPool;
        private float _deltaX;
        private float _deltaY;
        private float _magnitude;
        private float _normalisedX;
        private float _normalisedY;

        public Fireball(string name, Bitmap bitmap, float x, float y, float speed, float mouseDirectionX, float mouseDirectionY, HealthPool healthPool) : base(name, bitmap, x, y)
        {
            _speed = speed;
             _deltaX = mouseX - X;
             _deltaY = mouseY - Y;
             _magnitude = MathF.Sqrt(_deltaX * _deltaX + _deltaY * _deltaY);
             _normalisedX = _deltaX / _magnitude;
             _normalisedY = _deltaY / _magnitude;
            _directionX = mouseDirectionX;
            _directionY = mouseDirectionY;

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
            
            
            X +=  normalisedX * _speed;
            Y += normalisedY * _speed;
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
        public float mouseX
        {
            get { return _mouseX; }
            set { _mouseX = value; }
        }
        public float mouseY
        {
            get { return _mouseY; }
            set { _mouseY = value; }
        }
        public float normalisedX
        {
            get { return _normalisedX; }
            set { _normalisedX = value; }
        }
        public float normalisedY
        {
            get { return _normalisedY; }
            set { _normalisedY = value; }
        }
        
    }
}
