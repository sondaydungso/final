using customfinal.Common;
using customfinal.Managers;
using SplashKitSDK;

namespace customfinal.ConcreteClasses.PowerUps
{
    public class PowerUp : GameObject
    {
        private Bitmap _bitmap;
        private bool isDestroyed = false;

        public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }

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
            GameManager.Instance.PowerUpManager.KillPowerUp(this);
        }
        public virtual void ApplyPowerUp(Player player)
        {

        }


    }
}
