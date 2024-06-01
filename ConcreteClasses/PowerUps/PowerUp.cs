using customfinal.Common;
using customfinal.ConcreteClasses;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal.ConcreteClasses.PowerUps
{
    public class PowerUp : GameObject
    {
        private Bitmap _bitmap;
        public PowerUp(string name, Bitmap bitmap, float x, float y) : base(name, bitmap, x, y)
        {
            _bitmap = bitmap;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(_bitmap, X, Y);
        }
        public override void DestroySelf()
        {

        }
        public virtual void ApplyPowerUp(Player player)
        {

        }


    }
}
