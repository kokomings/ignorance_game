using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class Human : IUpdatable, IDrawable
    {
        private readonly IShape shape;
        private readonly Movement movement;
        private readonly CharacterStatus characterStatus;
        private Body body;

        public IShape Shape => shape;
        public IMovement Movement => movement;
        public IMovementForPlayer PlayerMovement => movement;

        public Human(IShape shape, Vector3 position, Vector2 direction)
        {
            this.shape = shape;
            this.movement = new Movement(position, direction);
            var baseStat = new Stat { HP = 100, MoveSpeed = 1.0f };
            this.characterStatus = new CharacterStatus(baseStat);
            this.body = new Body(baseStat.HP);
        }

        public void Update()
        {
            Movement.Move(characterStatus.GetTotalStat().MoveSpeed);
        }
    }
}
