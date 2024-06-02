using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.ConcreteClasses.PowerUps
{
    public class PowerUpMovementSpeed : PowerUp
    {

        private float _amount;
        
        public PowerUpMovementSpeed(string name, Bitmap bitmap, float x, float y, float amount = 1) : base(name, bitmap, x, y)
        {
            _amount = amount;
            

        }
        public override void ApplyPowerUp(Player player)
        {
            player.Speed += _amount;

        }
        public override void DestroySelf()
        {
            base.DestroySelf();
        }


    }

}
