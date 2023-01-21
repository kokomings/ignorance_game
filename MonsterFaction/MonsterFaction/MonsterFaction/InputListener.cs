using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.SingleUserControl;

namespace MonsterFaction
{
    public class InputListener
    {
        private static readonly InputListener inputListener = new();
        private readonly PlayerController playerController = new();

        public static InputListener Input => inputListener;

        public void SetPlayerMovement(IMovementForPlayer playerMovement)
            => this.playerController.PlayerMovement = playerMovement;

        public void UpButton_Down()
        {
            playerController.MoveToUp(true);
        }

        public void UpButton_Up()
        {
            playerController.MoveToUp(false);
        }

        public void DownButton_Down()
        {
            playerController.MoveToDown(true);
        }
        public void DownButton_Up()
        {
            playerController.MoveToDown(false);
        }

        public void LeftButton_Down()
        {
            playerController.MoveToLeft(true);
        }
        public void LeftButton_Up()
        {
            playerController.MoveToLeft(false);
        }

        public void RightButton_Down()
        {
            playerController.MoveToRight(true);
        }

        public void RightButton_Up()
        {
            playerController.MoveToRight(false);
        }

        // R  or switch(A) or xbox(Y)
        public void Interaction() { }

        // Space or switch(X) or xbox(A)
        public void Space() { }

        public void Acceleration_Down()
        {
            playerController.Acceleration(true);
        }

        public void Acceleration_Up()
        {
            playerController.Acceleration(false);
        }

        public void Attack_Down()
        {
            // TODO 구조 개선하고 구현.
        }

        //  Backspace or switch(+)
        public void Status() { }

        // Esc or switch(-) or xbox(ESC)
        public void Menu() { }

        // Q or switch(ZL) or xbox(LT)
        public void TopLeft() { }

        // E or switch(ZR) or xbox(RT)
        public void TopRight() { }
    }
}
