using customfinal.Common;
using customfinal.Managers;
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
        private bool _isDestroyed = false;

        public Barrier(string name, Bitmap bitmap, float x, float y, int maxHP) : base(name, bitmap, x, y)
        {

            _heathPool = new HealthPool(maxHP, maxHP);

        }

        public override void Draw()
        {
            if (!IsDestroyed)
            {
                SplashKit.DrawBitmap(Bitmap, X, Y);
            }
        }

        public override void DestroySelf()
        {
            GameManager.Instance.BarrierManager.KillBarrier(this);

        }


        public HealthPool HealthPool
        {
            get { return _heathPool; }
            set { _heathPool = value; }
        }

        public bool IsDestroyed { get => _isDestroyed; set => _isDestroyed = value; }
        //TODO: finish implememtation of barrier and barrier manager

    }

}
