using MonsterFaction.GameWorld.WorldObject.Shape;
using System;
using System.Numerics;

namespace MonsterFaction.SingleUserControl
{
    public struct MovementInput
    {
        public bool isUpPressed;
        public bool isDownPressed;
        public bool isLeftPressed;
        public bool isRightPressed;

        public bool isAccelerationPressed;
    }

    public class PlayerController
    {
        // 어딘가에 각도 모듈화 하면 좋을 듯. radian에서 vector 얻는 것도 확장 메서드로...
        private const float RADIAN_0 = 0.0f;
        private const float RADIAN_90 = 1.5708f;
        private const float RADIAN_180 = 3.14159f;
        private const float RADIAN_270 = 4.71239f;
        private static readonly Vector2 Up = new(MathF.Cos(RADIAN_90), MathF.Sin(RADIAN_90));
        private static readonly Vector2 Down = new(MathF.Cos(RADIAN_270), MathF.Sin(RADIAN_270));
        private static readonly Vector2 Left = new(MathF.Cos(RADIAN_180), MathF.Sin(RADIAN_180));
        private static readonly Vector2 Right = new(MathF.Cos(RADIAN_0), MathF.Sin(RADIAN_0));

        private static readonly float WALK_SPEED = 1.0f;
        private static readonly float RUN_SPEED = 3.0f;

        private IMovementForPlayer playerMovement;
        private MovementInput movementInput;

        public IMovementForPlayer PlayerMovement
        {
            set { playerMovement = value; }
        }

        public void MoveToUp(bool enable)
        {
            movementInput.isUpPressed = enable;
            MoveOrStop();
        }

        public void MoveToDown(bool enable)
        {
            movementInput.isDownPressed = enable;
            MoveOrStop();
        }

        public void MoveToLeft(bool enable)
        {
            movementInput.isLeftPressed = enable;
            MoveOrStop();
        }

        public void MoveToRight(bool enable)
        {
            movementInput.isRightPressed = enable;
            MoveOrStop();
        }

        public void Acceleration(bool enable)
        {
            movementInput.isAccelerationPressed = enable;
            MoveOrStop();
        }

        private void MoveOrStop()
        {
            if (movementInput.isUpPressed || movementInput.isDownPressed || movementInput.isLeftPressed || movementInput.isRightPressed)
            {
                Move();
            }
            else
            {
                Stop();
            }
        }

        private void Move()
        {
            var speed = movementInput.isAccelerationPressed ? RUN_SPEED : WALK_SPEED;
            var newDirection = Vector2.Zero;
            if (movementInput.isUpPressed)
            {
                newDirection += Up;
            }
            if (movementInput.isDownPressed)
            {
                newDirection += Down;
            }
            if (movementInput.isLeftPressed)
            {
                newDirection += Left;
            }
            if (movementInput.isRightPressed)
            {
                newDirection += Right;
            }
            playerMovement.Direction = newDirection;

            playerMovement.Velocity = new Vector3(
                playerMovement.Direction.X * speed,
                0,
                playerMovement.Direction.Y * speed);
        }

        private void Stop()
        {
            playerMovement.Velocity = Vector3.Zero;
        }
    }
}
