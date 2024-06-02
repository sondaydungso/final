using customfinal.Common;
using customfinal.Managers;
using SplashKitSDK;


namespace customfinal.ConcreteClasses
{
    public class Barrier : GameObject
    {
        private HealthPool _heathPool;
        private bool _isDestroyed = false;
       

        public Barrier(string name, Bitmap bitmap, float x, float y, int maxHP) : base(name, bitmap, x, y)
        {
            _heathPool = new HealthPool(maxHP, maxHP);
        }

        public override void Draw()
        {
            if (!IsDestroyed)
            {
               
                SplashKit.DrawBitmap(Bitmap, X, Y);
            }
        }

        public override void DestroySelf()
        {
            GameManager.Instance.BarrierManager.KillBarrier(this);
        }

        public void Hurt(int damage)
        {
            HealthPool.TakeDamage(damage);
            if (HealthPool.CurrentHealth <= 0)
            {
                DestroySelf();
            }
        }

        public HealthPool HealthPool
        {
            get { return _heathPool; }
            set { _heathPool = value; }
        }

        public bool IsDestroyed { get => _isDestroyed; set => _isDestroyed = value; }

        
    }

}
