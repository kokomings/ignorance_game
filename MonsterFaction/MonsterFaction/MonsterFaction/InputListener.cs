using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.DomainObject;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;

namespace MonsterFaction
{
    public class InputListener : IUpdatable
    {
        private readonly HumanObjectManager humanObjectManager;

        private bool up; private Direction upDirection = new Direction(0, 1);
        private bool down; private Direction downDirection = new Direction(0, -1);
        private bool left; private Direction leftDirection = new Direction(-1, 0);
        private bool right; private Direction rightDirection = new Direction(1, 0);
        private bool acceleration;

        public InputListener(HumanObjectManager humanObjectManager)
        {
            this.humanObjectManager = humanObjectManager;
        }
        public void UpButton_Down()
        {
            up = true;
        }

        public void UpButton_Up()
        {
            up = false;
        }

        public void DownButton_Down()
        {
            down = true;
        }
        public void DownButton_Up()
        {
            down = false;
        }

        public void LeftButton_Down()
        {
            left = true;
        }
        public void LeftButton_Up()
        {
            left = false;
        }

        public void RightButton_Down()
        {
            right = true;
        }

        public void RightButton_Up()
        {
            right = false;
        }
        public void Acceleration_Down()
        {
            acceleration = true;
        }

        public void Acceleration_Up()
        {
            acceleration = false;
        }

        // R  or switch(A) or xbox(Y)
        public void Interaction() { }

        // Space or switch(X) or xbox(A)
        public void Space() { }

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

        public void Update()
        {
            Direction direction = new(0, 0);
            if (left)
                direction += leftDirection;
            if (right)
                direction += rightDirection;
            if (up)
                direction += upDirection;
            if (down)
                direction += downDirection;

            double speed = acceleration ? 3 : 1;
            humanObjectManager.Move(direction, speed);
        }
    }
}
