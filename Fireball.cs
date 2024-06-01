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
        private float _magnitude;
        private float _normalisedX;
        private float _normalisedY;
        private HealthPool _healthPool;

        public Fireball(string name, Bitmap bitmap, float spawnX, float spawnY, float speed, float mouseDirectionX, float mouseDirectionY, HealthPool healthPool) : base(name, bitmap, spawnX, spawnY)
        {
             _speed = speed;

            _healthPool = healthPool;

            // Calculate the direction towards the target   
             var deltaX = mouseDirectionX - X;
             var deltaY = mouseDirectionY - Y;
             _magnitude = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);
             _normalisedX = deltaX / _magnitude;
             _normalisedY = deltaY / _magnitude;
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
            X +=  NormalisedX * _speed;
            Y += NormalisedY * _speed;

            if (IsOutOfBounds())
            {
                DestroySelf();
            }
        }

        private bool IsOutOfBounds()
        {
            return X < 0 || X > 900 || Y < 0 || Y > 700;
        }

        public void Hurt(int damage)
        {
            HealthPool.TakeDamage(damage);
        }
        public void RegisterAsMoveable()
        {
            GameManager.AddMoveable(this);
            GameManager.AddGameObject(this);
        }
        public HealthPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }
        public float NormalisedX
        {
            get { return _normalisedX; }
            set { _normalisedX = value; }
        }
        public float NormalisedY
        {
            get { return _normalisedY; }
            set { _normalisedY = value; }
        }
        
    }
}
