﻿using MonsterFaction.GameWorld;
using MonsterFaction.SingleUserControl;
using System;

namespace MonsterFaction
{
    public class Program
    {
        public static void Main()
        {
            var game = new Game();
            game.Start();

            while (true)
            {
                game.GameLoop();
            }
        }
    }

    public class Game
    {
        private readonly TimeSpan MS_PER_UPDATE = TimeSpan.FromMilliseconds(8.0);
        private DateTime previousGameTime = DateTime.Now;
        private TimeSpan lag = TimeSpan.Zero;

        private readonly PlayerController playerController = new();
        private readonly World gameWorld = new();
        public IDrawableWorld GameWorld => gameWorld;

        public Game()
        {
            playerController.PlayerMovement = gameWorld.MakePlayer().PlayerMovement;
        }

        public void GameLoop()
        {
            var currentGameTime = DateTime.Now;
            var elapsed = currentGameTime - previousGameTime;
            previousGameTime = currentGameTime;
            lag += elapsed;

            // processInput();

            while (lag >= MS_PER_UPDATE)
            {
                this.Update();
                lag -= MS_PER_UPDATE;
            }

            // render();
        }

        public void Start()
        {
            Logger.Log.Information("Hello World!");
        }

        public void Update()
        {
            Logger.Log.Information("Hi!");
            gameWorld.Update();
        }
    }
}
