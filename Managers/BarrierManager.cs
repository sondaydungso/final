using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SplashKitSDK;
namespace customfinal.Managers
{
    public class BarrierManager
    {
        private List<Barrier> _barriers = new List<Barrier>();
        public List<Barrier> Barriers { get => _barriers; set => _barriers = value; }
        public BarrierManager()
        {
         
        }
        public void SpawnBarrier()
        {
            Random random = new Random();
            int x = random.Next(0, Constants.GameWindow.Width);
            int y = random.Next(0, Constants.GameWindow.Height);
            Barrier barrier = new Barrier("Barrier", SplashKit.BitmapNamed("Barrier"), x, y);
            Barriers.Add(barrier);
        }


    }
}
