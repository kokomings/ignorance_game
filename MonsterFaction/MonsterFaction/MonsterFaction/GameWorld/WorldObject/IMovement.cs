using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject
{
    public interface IMovement
    {
        public Center Center { get; }
        public Direction Direction { get; }
        public void Move();
        public Center NextPosition();
    }
}
