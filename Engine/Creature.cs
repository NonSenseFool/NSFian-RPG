using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class Creature : INotifyPropertyChanged
    {
        public int MaximumHealth { get; set; }
        private int _currentHealth;

        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
                OnPropertyChanged("CurrentHealth");
            }
        }

        public Creature(int currentHealth, int maximumHealth)
        {
            CurrentHealth = currentHealth;
            MaximumHealth = maximumHealth;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
