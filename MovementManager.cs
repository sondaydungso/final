using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class MovementManager
    {
        private static readonly MovementManager instance = new MovementManager();
        private static List<IMoveable> _moveables = new List<IMoveable>();
        private static Player _player;

        static MovementManager()
        {
        }

         private MovementManager()
        {
        }

        public static MovementManager Instance
        {
            get
            {
                return instance;
            }
        }
        public static Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        //add enemies and bullets using this method
        //then when the game runs, this manager will move all of those objects
        public static void AddMoveable(IMoveable moveable)
        {
            _moveables.Add(moveable);
        }

        public static void MoveAll()
        {
            foreach (IMoveable moveable in _moveables)
            {
                moveable.Move();
            }
        }
        
    }
}
