using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class GameManager
    {
        private static readonly GameManager instance = new GameManager();
        //draw all of this
        private static List<GameObject> _gameObjects = new List<GameObject>();

        //move all of this
        private static List<IMoveable> _moveables = new List<IMoveable>();

        private static Player _player;

        static GameManager()
        {
        }

         private GameManager()
        {
        }

        public static GameManager Instance
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
        public static void RemoveMoveable(IMoveable moveable)
        {
            //_moveables.Remove(moveable);
        }

        public static void MoveAll()
        {
            foreach (IMoveable moveable in _moveables)
            {
                moveable.Move();
            }
        }

        public static void AddGameObject(GameObject obj)
        {
            _gameObjects.Add(obj);
        }

        public static void RemoveGameObject(GameObject obj)
        {
            _gameObjects.Remove(obj);
        }

        public static void Update()
        {
            foreach (GameObject obj in _gameObjects)
            {
                obj.Draw();
            }
        }
    }
}
