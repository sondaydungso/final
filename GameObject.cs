using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public abstract class GameObject
    {
        private Bitmap _bitmap;
        private string _name;
        private float _x, _y;
        //private int _health;
        public GameObject(string name, Bitmap bitmap, float x, float y)
        {
            Name = name;
            Bitmap = bitmap;
            X = x;
            Y = y;
        }
        public abstract void Draw();

        public abstract void DestroySelf();
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        //public int Health
        //{
        //    get { return _health; }
        //    set { _health = value; }
        //}
    }
}
