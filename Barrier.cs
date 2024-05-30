using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class Barrier : GameObject
    {
        private Collider _collider;
        private Bitmap _bitmap;
        private HeathPool _heathPool;

        public Barrier(string name, Bitmap bitmap, float x, float y, Collider collider, HeathPool heathPool) : base(name, bitmap, x, y, collider)
        {
            _bitmap = SplashKit.BitmapNamed(""); //Add this when find the asset
            _heathPool = heathPool;
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, X, Y);
        }

        public override void DestroySelf()
        {
            SplashKit.FreeBitmap(_bitmap);
        }
        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        public HeathPool HeathPool
        {
            get { return _heathPool; }
            set { _heathPool = value; }
        }
    }
    
}
