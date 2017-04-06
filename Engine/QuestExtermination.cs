using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestExtermination : Quest
    {
        public Monster MonsterToExterminate { get; set; }
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
        public bool IsComplete { get; set; }

        public QuestExtermination(int id, string name, string description, int rewardExperiencePoints, int rewardGold,
            Monster monsterToExterminate, int requiredAmount)
            : base(id, name, description, rewardExperiencePoints, rewardGold)
        {
            MonsterToExterminate = monsterToExterminate;
            RequiredAmount = requiredAmount;
            CurrentAmount = 0;
            IsComplete = false;
        }
    }
}