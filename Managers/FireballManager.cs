using customfinal.ConcreteClasses;
using SplashKitSDK;

namespace customfinal.Managers
{
    public class FireballManager
    {
        private float _fireballSpeed = 10f;

        private List<Fireball> _fireballs = new List<Fireball>();

        public List<Fireball> Fireballs { get => _fireballs; set => _fireballs = value; }

        public FireballManager()
        {
        }
        //spawn fireball at a position
        public void SpawnFireball(float x, float y, float directionX, float directionY, int damage)
        {
            Fireball fireball = new Fireball("fireball", SplashKit.BitmapNamed("Fireball"), x, y, _fireballSpeed, directionX, directionY, damage);
            _fireballs.Add(fireball);
        }
        // draw fireballs
        public void DrawAllFireballs()
        {
            foreach (Fireball fireball in _fireballs)
            {
                if (!fireball.IsDestroyed)
                {
                    fireball.Draw();
                }
            }
        }
        //kill off everything 
        public void ClearAllFireballs()
        {
            _fireballs.Clear();
        }

        //delete all fireballs that are destroyed
        public void ClearAllDestroyedFireballs()
        {
            _fireballs.RemoveAll(fireball => fireball.IsDestroyed);
        }

        //move all fireballs
        public void MoveAllFireballs()
        {
            foreach (Fireball fireball in _fireballs)
            {
                if (fireball.IsDestroyed == false)
                {
                    fireball.Move();
                }
            }
        }
        //kill a fireball
        public void KillFireball(Fireball fireball)
        {
            fireball.IsDestroyed = true;
        }

        
    }
}
