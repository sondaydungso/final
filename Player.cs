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
        private Bitmap _bitmap;
        private float _speed;
        private HeathPool _healthPool;
        public Player(string name, Bitmap bitmap, float x, float y, float speed, HeathPool healthPool) : base(name, bitmap, x, y)
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
