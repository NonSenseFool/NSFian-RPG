using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : Creature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        //public bool AppearsOnce { get; set; }

        public List<LootItem> LootTable { get; set; }

        public Monster
            (int id, string name, int minimumDamage, int maximumDamage,
            int rewardExperiencePoints, int rewardGold, int currentHealth, int maximumHealth)
            : base(currentHealth, maximumHealth)
        {
            ID = id;
            Name = name;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            //AppearsOnce = appearsOnce;
            LootTable = new List<LootItem>();
        }
    }
}