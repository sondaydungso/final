using Barrier = customfinal.ConcreteClasses.Barrier;

using SplashKitSDK;
using customfinal.ConcreteClasses;
namespace customfinal.Managers
{
    public class BarrierManager
    {
        private List<Barrier> _barriers = new List<Barrier>();
        public List<Barrier> Barriers { get => _barriers; set => _barriers = value; }
        public BarrierManager()
        {
         
        }
        public void SpawnBarrierRandomPos()
        {
            Random random = new Random();
            int x = random.Next(0, Constants.GameWindow.Width);
            int y = random.Next(0, Constants.GameWindow.Height);
            Barrier barrier = new Barrier("Barrier", SplashKit.BitmapNamed("Barrier"), x, y, 20);
            _barriers.Add(barrier); 
        }
        public void SpawnBarrier(float x, float y)
        {
            Barrier barrier = new Barrier("Barrier", SplashKit.BitmapNamed("Barrier"), x, y, 20);
            _barriers.Add(barrier);
        }
        //draw all barriers
        public void DrawAllBarriers()
        {
            foreach (Barrier barrier in _barriers)
            {
                barrier.Draw();
            }
        }
        //spawn more barriers
        public void SpawnMore()
        {
            Random random = new Random();
            int x = random.Next(0, Constants.GameWindow.Width);
            int y = random.Next(0, Constants.GameWindow.Height);
            int spawnrate = random.Next(0, 100);
            if (Barriers.Count == 0)
            {
                for (int i = 0; i < spawnrate / 2; i++)
                {
                    SpawnBarrierRandomPos();
                }
            }

        }
        //clear all barriers
        public void ClearAllBarriers()
        {
            _barriers.Clear();
        }
        //clear all destroyed barriers
        public void ClearAllDestroyedBarriers()
        {
            _barriers.RemoveAll(barrier => barrier.IsDestroyed);
        }
        //kill a barrier
        public void KillBarrier(Barrier barrier)
        {
            barrier.IsDestroyed = true;
        }
        


    }
}

