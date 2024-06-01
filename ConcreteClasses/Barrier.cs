using customfinal.Common;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal.ConcreteClasses
{
    public class Barrier : GameObject
    {


        private HealthPool _heathPool;


        public Barrier(string name, Bitmap bitmap, float x, float y, HealthPool heathPool) : base(name, bitmap, x, y)
        {

            _heathPool = heathPool;

        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
        }

        public override void DestroySelf()
        {


        }


        public HealthPool HealthPool
        {
            get { return _heathPool; }
            set { _heathPool = value; }
        }
        //TODO: finish implememtation of barrier and barrier manager

    }

}
