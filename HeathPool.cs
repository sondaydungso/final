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
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }
        public int MaxHealth
        {
            
            set { _maxHealth = value; }
        }
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
            }
        }
        public void Heal(int amount)
        {
            _currentHealth += amount;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
