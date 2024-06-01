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

        public void SpawnFireball(float x, float y, float directionX, float directionY, int damage)
        {
            Fireball fireball = new Fireball("fireball", SplashKit.BitmapNamed("Fireball"), x, y, _fireballSpeed, directionX, directionY, damage);
            _fireballs.Add(fireball);
        }

        //kill off everything and de-reference it from GameManager so that garbage collection can do the cleaning
        public void ClearAllFireballs()
        {
            _fireballs.Clear();
        }

        public void ClearAllDestroyedFireballs()
        {
            _fireballs.RemoveAll(fireball => fireball.IsDestroyed);
        }

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

        public void KillFireball(Fireball fireball)
        {
            fireball.IsDestroyed = true;
        }

        public void ClearFireball(Fireball fireball)
        {
            _fireballs.Remove(fireball);
        }
    }
}
