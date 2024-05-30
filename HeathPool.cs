using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class HeathPool
    {
        private int _currentHealth;
        private int _maxHealth;
        public HeathPool(int maxHealth, int currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }
        public int CurrentHealth
        {
            
            set { _currentHealth = value; }
        }
        public int MaxHealth
        {
            
            set { _maxHealth = value; }
        }
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }
        public void Heal(int amount)
        {
            _currentHealth += amount;
        }
    }
}
