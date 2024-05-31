using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customfinal
{
    public class PowerUpFactory
    {
        private static readonly PowerUpFactory instance = new PowerUpFactory();
        private static List<PowerUp> _powerUps = new List<PowerUp>();
        private Random _random ;
        //private static List<PowerUp> _available = new List<PowerUp>()
        //{
            
        //};


        static PowerUpFactory()
        {
            
        }
         private PowerUpFactory()
        {
        }
        public static PowerUpFactory Instance
        {
            get
            {
                return instance;
            }
        }
        public static void PowerUpPickupCheck()
        {
            int i = 0;
            foreach (PowerUp powerUp in _powerUps)
            {
                if (i == 0) //Add logic to check collision here
                {
                    powerUp.ApplyPowerUp(MovementManager.Player);
                    _powerUps.Remove(powerUp);
                    break;
                }
            }
        }
        public static void SpawnPowerUp(PowerUp powerUp)
        {
            _powerUps.Add(powerUp);
        }
        
    }
}
