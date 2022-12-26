using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class Human : Character, IUpdatable, IDrawable
    {
        private readonly IShape shape;
        private readonly Movement movement;

        public IShape Shape => shape;
        public IMovement Movement => movement;
        public IMovementForPlayer PlayerMovement => movement;

        public Human(IShape shape, Vector3 position, Vector2 direction): base(new Stat { HP = 100, MoveSpeed = 1.0f })
        {
            this.shape = shape;
            this.movement = new Movement(position, direction);
        }

        public void Update()
        {
            Movement.Move(characterStatus.GetTotalStat().MoveSpeed);
        }
    }
}
