using MonsterFaction.GameWorld.WorldObject.Shape;

namespace MonsterFaction.SingleUserControl
{
    public class PlayerController
    {
        private IMovementForPlayer playerMovement;
        public IMovementForPlayer PlayerMovement
        {
            set { playerMovement = value; }
        }
    }
}
