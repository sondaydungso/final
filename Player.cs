using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class Player : GameObject, IMoveable
    {
        private float _speed;
        private HealthPool _healthPool;
        private int _damage;
        public Player(string name, Bitmap bitmap, float x, float y, float speed, int damage, HealthPool healthPool) : base(name, bitmap, x, y)
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
           SplashKit.FreeBitmap(Bitmap);
        }
        public void RegisterAsMoveable()
        {
            MovementManager.AddMoveable(this);
        }
        public void Move()
        {
            if (SplashKit.KeyDown(KeyCode.WKey))
            {
                Y -= _speed;
            }
            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                Y += _speed;
            }
            if (SplashKit.KeyDown(KeyCode.AKey))
            {
                X -= _speed;
            }
            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                X += _speed;
            }
        }

        public HealthPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }
        
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
    }
}
