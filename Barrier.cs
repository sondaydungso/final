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
        
        
        private HealthPool _heathPool;
        private bool _disposed;

        public Barrier(string name, Bitmap bitmap, float x, float y, HealthPool heathPool) : base(name, bitmap, x, y)
        {
            
            _heathPool = heathPool;
            _disposed = false;
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
        }

        public override void DestroySelf()
        {
            if (_disposed == true)
            {
                SplashKit.FreeBitmap(Bitmap);
            }                       
        }
        
        
        public HealthPool HeathPool
        {
            get { return _heathPool; }
            set { _heathPool = value; }
        }
        public void Disposed()
        {
            if (_heathPool.CurrentHealth <= 0)
            {
                 _disposed = true;
            }
        }
    }
    
}
