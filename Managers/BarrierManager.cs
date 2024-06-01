using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SplashKitSDK;
using customfinal.ConcreteClasses;
namespace customfinal.Managers
{
    public class BarrierManager
    {
        private List<ConcreteClasses.Barrier> _barriers = new List<ConcreteClasses.Barrier>();
        public List<ConcreteClasses.Barrier> Barriers { get => _barriers; set => _barriers = value; }
        public BarrierManager()
        {
         
        }
        public void SpawnBarrierRandomPos()
        {
            Random random = new Random();
            int x = random.Next(0, Constants.GameWindow.Width);
            int y = random.Next(0, Constants.GameWindow.Height);
            ConcreteClasses.Barrier barrier = new ConcreteClasses.Barrier("Barrier", SplashKit.BitmapNamed("Barrier"), x, y, 9999);
            _barriers.Add(barrier); 
        }
        public void SpawnBarrier(float x, float y)
        {
            ConcreteClasses.Barrier barrier = new ConcreteClasses.Barrier("Barrier", SplashKit.BitmapNamed("Barrier"), x, y, 9999);
            _barriers.Add(barrier);
        }
        public void ClearAllBarriers()
        {
            _barriers.Clear();
        }
        public void ClearAllDestroyedBarriers()
        {
            _barriers.RemoveAll(barrier => barrier.IsDestroyed);
        }
        public void DrawAllBarriers()
        {
            foreach (ConcreteClasses.Barrier barrier in _barriers)
            {
                barrier.Draw();
            }
        }
        public void KillBarrier(ConcreteClasses.Barrier barrier)
        {
            barrier.IsDestroyed = true;
        }
        public void Clearbarriers(ConcreteClasses.Barrier b)
        {
            _barriers.Remove(b);
        }


    }
}
