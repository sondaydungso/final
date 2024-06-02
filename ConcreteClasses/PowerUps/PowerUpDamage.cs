using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.ConcreteClasses.PowerUps
{
    public class PowerUpDamage : PowerUp
    {
        

        public PowerUpDamage(string name, Bitmap bitmap, float x, float y) : base(name, bitmap, x, y)
        {
           

        }
        public override void ApplyPowerUp(Player player)
        {
            player.Damage += player.Damage + 1;
        }
        public override void DestroySelf()
        {
            base.DestroySelf();
        }
    }

}
