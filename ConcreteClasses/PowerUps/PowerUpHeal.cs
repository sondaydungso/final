﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.ConcreteClasses.PowerUps
{
    public class PowerUpHeal : PowerUp
    {
        private int _amount;

        public PowerUpHeal(string name, Bitmap bitmap, float x, float y, int amount = 3) : base(name, bitmap, x, y)
        {
            _amount = amount;

        }
        public override void ApplyPowerUp(Player player)
        {
            player.HealthPool.Heal(_amount);
        }
        public override void DestroySelf()
        {
            base.DestroySelf();
        }

    }

}
