using customfinal.Common;
using customfinal.Interfaces;
using customfinal.Managers;


using SplashKitSDK;


namespace customfinal.ConcreteClasses
{
    public class Player : GameObject, IMoveable
    {
        private float _speed;
        private HealthPool _healthPool;
        private int _damage;

        public Player(string name, Bitmap bitmap, float x, float y, float speed, int damage, int maxHp) : base(name, bitmap, x, y)
        {
            _speed = speed;
            _healthPool = new HealthPool(maxHp, maxHp);

            _damage = damage;

        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
            // Draw player HP on top of the player
            SplashKit.DrawText("HP: " + _healthPool.CurrentHealth, Color.Black, X, Y + 20);
        }
        public override void DestroySelf()
        {

        }

        public void Move()
        {
            //TODO: change the if else to switch statements
            if (SplashKit.KeyDown(KeyCode.WKey) && Y > 0 && GameManager.Instance.PlayerAllowedToMoveTo(X, Y - _speed))
            {
              
                Y -= _speed;
            }
            if (SplashKit.KeyDown(KeyCode.SKey) && Y < Constants.GameWindow.Height - Bitmap.Height && GameManager.Instance.PlayerAllowedToMoveTo(X, Y + _speed))
            {
                Y += _speed;
            }
            if (SplashKit.KeyDown(KeyCode.AKey) && X > 0 && GameManager.Instance.PlayerAllowedToMoveTo(X - _speed, Y))
            {
                X -= _speed;
            }
            if (SplashKit.KeyDown(KeyCode.DKey) && X < Constants.GameWindow.Width - Bitmap.Width && GameManager.Instance.PlayerAllowedToMoveTo(X + _speed, Y))
            {
                X += _speed;
            }
        }
        
        public void Hurt(int damage)
        {
            HealthPool.TakeDamage(damage);

        }

        public void Shoot()
        {
            int playerdamage = Damage;
            //spawn fireball
            GameManager.Instance.FireballManager.SpawnFireball(X, Y, (float)SplashKit.MousePosition().X, (float)SplashKit.MousePosition().Y, playerdamage);
        }

        public HealthPool HealthPool
        {
            get { return _healthPool; }
            set { _healthPool = value; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
    }
}
