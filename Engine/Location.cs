using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestRequiredToEnter { get; set; }
        public Quest QuestAvailableHere { get; set; }
        public QuestExtermination QuestExterminationAvailableHere { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

        public Location
            (int id, string name, string description, Item itemRequiredToEnter = null, Quest questRequiredToEnter = null,
            Quest questAvailableHere = null, QuestExtermination questExterminationAvailableHere = null, Monster monsterLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestRequiredToEnter = questRequiredToEnter;
            QuestAvailableHere = QuestAvailableHere;
            QuestExterminationAvailableHere = questExterminationAvailableHere;
            MonsterLivingHere = monsterLivingHere;
        }
    }
}