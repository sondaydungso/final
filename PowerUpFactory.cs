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
                    powerUp.ApplyPowerUp(GameManager.Player);
                    _powerUps.Remove(powerUp);
                    break;
                }
            }
        }
        public static void SpawnPowerUp(PowerUp powerUp)
        {
            // Create a new instance of the Random class
            Random random = new Random();

            // Generate random x and y coordinates for the spawn position
            int x = random.Next(0, 1200);
            int y = random.Next(0, 800); 

            // Generate a random number to determine the type of power-up to spawn
            int powerUpType = random.Next(0, 2); // Assuming there are 2 types of power-ups (0 for heal, 1 for other type)

            // Create the corresponding power-up based on the generated type
            
            switch (powerUpType)
            {
                case 0:
                    powerUp = new PowerUpHeal("Heal Power-Up", SplashKit.BitmapNamed(""), x, y, 3); // Assuming there is a HealPowerUp class and bitmap is the power-up's image
                    break;
                case 1:
                    powerUp = new PowerUpDamage("Damage Power-Up", SplashKit.BitmapNamed(""), x, y, 5); // Assuming there is a DamagePowerUp class and bitmap is the power-up's image
                    break;
                case 2:
                    powerUp = new PowerUpMovementSpeed("Speed Power-Up", SplashKit.BitmapNamed(""), x, y, 3); // Assuming there is a SpeedPowerUp class and bitmap is the power-up's image
                    break;
            }
            

            // Add the power-up to the list
            _powerUps.Add(powerUp);
        }
        
    }
}
