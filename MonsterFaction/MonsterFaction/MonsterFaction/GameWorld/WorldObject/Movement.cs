﻿using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Numerics;

namespace MonsterFaction.GameWorld.WorldObject
{
    public sealed class Movement : IMovement, IMovementForPlayer
    {
        private Vector3 position;
        private Vector3 direction;
        private Vector3 velocity;
        public Vector3 Position => position;
        public Vector3 Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public Vector3 Velocity { set => velocity = value; }

        public Movement(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }

        public void Move()
        {
            position = position + velocity;
        }
    }
}
