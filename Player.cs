﻿using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class Player : GameObject, IMoveable
    {
        private float _speed;
        private HealthPool _healthPool;
        private int _damage;

        public Player(string name, Bitmap bitmap, float x, float y, float speed, int damage, HealthPool healthPool) : base(name, bitmap, x, y)
        {
            _speed = speed;
            _healthPool = healthPool;

            _damage = damage;
            
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
        }
        public override void DestroySelf()
        {
          
           
           
        }
        public void RegisterAsMoveable()
        {
            GameManager.AddMoveable(this);
        }
        public void Move()
        {
            // change the if else to switch statements
            if (SplashKit.KeyDown(KeyCode.WKey))
            {
                Y -= _speed;
            }
            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                Y += _speed;
            }
            if (SplashKit.KeyDown(KeyCode.AKey))
            {
                X -= _speed;
            }
            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                X += _speed;
            }
        }

        public void Shoot()
        {
            int playerdamage = this.Damage;
            //spawn fireball
            Fireball fireball = new Fireball("fireball",
                                             SplashKit.LoadBitmap("fireball", "C:\\Users\\tranp\\OneDrive\\Documents\\GitHub\\final\\Resource\\Fireball.png"),
                                             this.X, this.Y, 2, SplashKit.MouseX(), SplashKit.MouseY(), new HealthPool(playerdamage, playerdamage));
            fireball.RegisterAsMoveable();
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
