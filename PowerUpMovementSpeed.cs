using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customfinal
{
    public class PowerUpMovementSpeed : PowerUp
    {
        
        private float _amount;
        private float _duration;
        public PowerUpMovementSpeed(string name, Bitmap bitmap, float x, float y, float amount = 3, float duration = 5) : base(name, bitmap, x, y)
        {
            _amount = amount;
            _duration = duration;
            
        }
        public override void ApplyPowerUp(Player player)
        {
            player.Speed += _amount;
            
        }
        
        
    }
    
}
