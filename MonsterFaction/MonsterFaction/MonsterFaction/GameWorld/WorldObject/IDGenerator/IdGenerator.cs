using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.GameWorld.WorldObject.IDGenerator
{
    public static class IdGenerator
    {
        private static int nextObjectId = 1;
        public static int NextObjectId () { 
            return nextObjectId++;
        }
    }
}
