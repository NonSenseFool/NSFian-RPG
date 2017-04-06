using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static List<QuestExtermination> QuestExterminations = new List<QuestExtermination>();
        public static readonly List<Location> Locations = new List<Location>();

        // Item Drops, 1-1000
        public const int ITEM_ID_RAT_TAIL = 1;
        public const int ITEM_ID_PIECE_OF_FUR = 2;
        public const int ITEM_ID_SNAKE_FANG = 3;
        public const int ITEM_ID_SNAKESKIN = 4;
        public const int ITEM_ID_SPIDER_FANG = 5;
        public const int ITEM_ID_SPIDER_SILK = 6;
        // Weapons, 1001-1100
        public const int ITEM_ID_RUSTY_SWORD = 1001;
        public const int ITEM_ID_CLUB = 1002;
        public const int ITEM_ID_DEV_SWORD = 1100;
        // Key Items, 1101-1200
        public const int ITEM_ID_ADVENTURER_PASS = 1101;
        public const int ITEM_ID_SPIDER_HEART = 1102;
        public const int ITEM_ID_WORLD_MAP = 1103;
        // Healing Potions, 1201-1300
        public const int ITEM_ID_HEALING_POTION = 1201;

        public const int ITEM_ID_NULL = 9999;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;
        public const int MONSTER_ID_EXPERIENCE_SLIME = 4;
        public const int MONSTER_ID_SPIDER_QUEEN = 5;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
        public const int QUEST_ID_KILL_SPIDERS = 3;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        public const int LOCATION_ID_EXPERIENCE_CAVE = 10;
        public const int LOCATION_ID_SPIDER_NEST = 11;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {

            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of Fur", "Pieces of Fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake Fang", "Snake Fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider Fang", "Spider Fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider Silk", "Spider Silks"));

            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty Sword", "Rusty Swords", 0, 5));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new Weapon(ITEM_ID_DEV_SWORD, "Dev Sword", "Dev Swords", 100, 100));

            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer Pass", "Adventurer Passes"));
            Items.Add(new Item(ITEM_ID_SPIDER_HEART, "Spider Heart", "Spider hearts"));

            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 5));

            Items.Add(new Item(ITEM_ID_NULL, "", ""));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 1, 3, 2, 1, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 25, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 1, 5, 3, 2, 5, 5);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 25, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 3, 7, 5, 5, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 25, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 10, false));

            Monster experienceSlime = new Monster(MONSTER_ID_EXPERIENCE_SLIME, "Experience Slime", 0, 0, 100, 0, 1, 1);

            Monster spiderQueen = new Monster(MONSTER_ID_SPIDER_QUEEN, "Spider Queen", 10, 25, 75, 100, 50, 50);
            
            // Monster Template - ID, Name, Minimum Damage, Maximum Damage, EXP, Gold, Current HP, Max HP

            // Add the monsters to the static list
            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
            Monsters.Add(experienceSlime);
            Monsters.Add(spiderQueen);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Alchemist's Garden - Clear Rats",
                    "Kill the Rats in the Alchemist's Garden and bring back 3 Rat Tails. You will receive a Healing Potion and 10 gold pieces.", 10, 10);
            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));
            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Farmer's Field - Clear Snakes",
                    "Kill the Snakes in the Farmer's Field and bring back 3 Snake Fangs. You will receive an Adventurer's Pass and 20 gold pieces.", 20, 20);
            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));
            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            QuestExtermination killSpiders =
                new QuestExtermination(
                    QUEST_ID_KILL_SPIDERS,
                    "Kill Spiders - Test",
                    "You suspect that there is something deeper within the woods. Perhaps defeating the spiders found at the Spider Forest will allow you to go deeper.", 0, 0, MonsterByID(MONSTER_ID_GIANT_SPIDER), 5);
            killSpiders.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_NULL), 1));
            killSpiders.MonsterToExterminate = MonsterByID(MONSTER_ID_GIANT_SPIDER);
            killSpiders.RewardItem = ItemByID(ITEM_ID_SPIDER_HEART);

            // ADD A NEW QUEST COMPLETION TYPE, "EXTERMINATE X MONSTERS"

            // Add the quests to the static list
            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
            QuestExterminations.Add(killSpiders);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town Square", "A large fountain spews out fresh water in the center of the town. The busy lives of many walk through this core area of town everyday.");

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's Hut", "The surroundings are wild and full of life, dangerous or not. The strange aromas and herbs pique your interest inside.");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's Garden", "The surroundings are wild and full of life, dangerous or not. The garden contains various growing plants, many you don't comprehend fully.");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "The scent of fresh bread and a warmly greeting farmer meets you as you walk nearer.");
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's Field", "You see hard-working farmers that are currently tending to the crops. Many vegetables line the fields.");
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard Post", "There is a large, tough-looking guard here.");
            guardPost.ItemRequiredToEnter = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge worn down by nature sits upon a mighty river that is flowing quickly.");

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "Spider webs coat the trees and ground of this ominous area. Rustling can be heard all nearby and a glimpse of an eight-legged creature runs by.");
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);
            spiderField.QuestExterminationAvailableHere = ExterminationQuestByID(QUEST_ID_KILL_SPIDERS);

            Location experienceCave = new Location(LOCATION_ID_EXPERIENCE_CAVE, "Experience Cave", "Hidden away in the grass of the area, you find a small hole leading into a well-lit cave. Inside, strange yellow creatures are hopping about.");
            experienceCave.MonsterLivingHere = MonsterByID(MONSTER_ID_EXPERIENCE_SLIME);

            Location spiderNest = new Location(LOCATION_ID_SPIDER_NEST, "Spider Nest", "Deep within the forest of the spiders, you find an abnormally large spider. She looks like the queen, and she is clearly dangerous and unhappy to see you.");
            spiderNest.ItemRequiredToEnter = ItemByID(ITEM_ID_SPIDER_HEART);
            spiderNest.MonsterLivingHere = MonsterByID(MONSTER_ID_SPIDER_QUEEN);

            // Location Template - ID, Name, Description, Item Needed

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToWest = farmhouse;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;

            farmhouse.LocationToWest = farmersField;
            farmhouse.LocationToEast = townSquare;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToNorth = alchemistsGarden;
            alchemistHut.LocationToSouth = townSquare;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToWest = townSquare;
            guardPost.LocationToEast = bridge;

            bridge.LocationToNorth = experienceCave;
            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;
            spiderField.LocationToEast = spiderNest;

            experienceCave.LocationToSouth = bridge;

            spiderNest.LocationToWest = spiderField;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
            Locations.Add(experienceCave);
            Locations.Add(spiderNest);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static QuestExtermination ExterminationQuestByID(int id)
        {
            foreach (QuestExtermination exterminationQuest in QuestExterminations)
            {
                if (exterminationQuest.ID == id)
                {
                    return exterminationQuest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}