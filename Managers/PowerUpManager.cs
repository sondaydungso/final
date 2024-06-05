using SplashKitSDK;
using customfinal.ConcreteClasses.PowerUps;


namespace customfinal.Managers
{
    public class PowerUpManager
    {
        private List<PowerUp> _powerUps;
        
        private int _framesUntilSpawn = 300;
        private int _framesLeftUntilSpawn = 300;

        public List<PowerUp> PowerUps { get => _powerUps; set => _powerUps = value; }

        public PowerUpManager()
        {
            _powerUps = new List<PowerUp>();
        }

        //spawn power up at random position
        public void SpawnPowerUpRandomPos()
        {
            Random random = new Random();
            int x = random.Next(0, Constants.GameWindow.Width);
            int y = random.Next(0, Constants.GameWindow.Height);
            int powerUpType = random.Next(0, 3); //  there are 3 types of power-ups (0 for heal, 1 for speed boost, 2 for damage boost )

            PowerUp powerUp;
            switch (powerUpType)
            {
                case 0:
                    powerUp = new PowerUpHeal("PowerUpHeal", SplashKit.BitmapNamed("PowerUpHeal"), x, y);
                    break;
                case 1:
                    powerUp = new PowerUpMovementSpeed("PowerUpSpeed", SplashKit.BitmapNamed("PowerUpSpeed"), x, y);
                    break;
                case 2:
                    powerUp = new PowerUpDamage("PowerUpDamage", SplashKit.BitmapNamed("PowerUpDamage"), x, y);
                    break;
                default:
                    powerUp = new PowerUpHeal("PowerUpHeal", SplashKit.BitmapNamed("PowerUpHeal"), x, y);
                    break;
            }
            if (powerUp != null)
            {
                _powerUps.Add(powerUp);
            }
            


        }
        //spawn power up at a position
        public void SpawnPowerUp(float x, float y, int powerUpType) // there are 3 types of power-ups (0 for heal, 1 for speed boost, 2 for damage boost )
        {
            if (powerUpType == 0)
            {
                PowerUp powerUp = new PowerUpHeal("PowerUpHeal", SplashKit.BitmapNamed("PowerUpHeal"), x, y);
                _powerUps.Add(powerUp);
            }
            else if (powerUpType == 1)
            {
                PowerUp powerUp = new PowerUpMovementSpeed("PowerUpSpeed", SplashKit.BitmapNamed("PowerUpSpeed"), x, y);
                _powerUps.Add(powerUp);
            }
            else if (powerUpType == 2)
            {
                PowerUp powerUp = new PowerUpDamage("PowerUpDamage", SplashKit.BitmapNamed("PowerUpDamage"), x, y);
                _powerUps.Add(powerUp);
            }
        }
        //check if player collides with power up
        public void SpawnMore()
        {
            if (_framesLeftUntilSpawn > 0)
            {
                _framesLeftUntilSpawn--;
            }
            
            if (_powerUps.Count == 0 && _framesLeftUntilSpawn <= 0)
            {
                SpawnPowerUpRandomPos();
                _framesLeftUntilSpawn = _framesUntilSpawn;
            }

        }
        //draw all power ups
        public void DrawAllPowerUps()
        {
            foreach (PowerUp powerUp in _powerUps)
            {
                powerUp.Draw();
            }
        }
        //kill off everything to restart the game
        public void ClearAllPowerUps()
        {
            _powerUps.Clear();
        }
        //delete all power ups that are destroyed
        public void ClearAllDestroyedPowerUps()
        {
            _powerUps.RemoveAll(powerUp => powerUp.IsDestroyed);
        }
        //kill a power up
        public void KillPowerUp(PowerUp powerUp)
        {
            powerUp.IsDestroyed = true;
        }
       


    }
}
