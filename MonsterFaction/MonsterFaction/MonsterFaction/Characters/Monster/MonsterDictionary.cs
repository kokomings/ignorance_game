using System;
using System.Collections.Generic;

namespace MonsterFaction.Characters.Monster
{
    class MonsterDictionary
    {
        private Dictionary<MonsterName, Stat> monsterStatDictionary = new();
        public MonsterDictionary() 
        {
            initialize();
            validateDictionary();
        }

        public Stat GetStat(MonsterName monsterName)
        {
            return monsterStatDictionary[monsterName];
        }
        private void initialize()
        {
            monsterStatDictionary.Add(MonsterName.GOBLIN, new Stat());
        }

        private void validateDictionary()
        {
            foreach(MonsterName name in Enum.GetValues(typeof(MonsterName)))
            {
                if (!monsterStatDictionary.ContainsKey(name)) 
                {
                    throw new ApplicationException("There is an empty key in the monster stat dictionary.");
                }
            }
        }
    }
}
