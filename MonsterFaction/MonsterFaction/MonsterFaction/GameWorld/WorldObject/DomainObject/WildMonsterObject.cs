using MonsterFaction.Characters.Monster;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class WildMonsterObject : SimpleObject
    {
        private WildMonster WildMonster { get; }
        public WildMonsterObject(WildMonster wildMonster, IShape shape, Center center) : base(shape, center) 
        {
            WildMonster = wildMonster;
        }
    }
}
