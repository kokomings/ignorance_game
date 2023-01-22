using MonsterFaction.GameWorld;
using MonsterFaction.SystemEvents;
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

        private readonly EventSubscriber<CreateEvent> eventSubscriber = new(EventType.OBJECT_CREATE);
        private readonly World gameWorld = new();
        public IDrawableWorld GameWorld => gameWorld;

        public Game()
        {
            gameWorld.MakePlayer();
        }

        public void GameLoop()
        {
            var currentGameTime = DateTime.Now;
            var elapsed = currentGameTime - previousGameTime;
            previousGameTime = currentGameTime;
            lag += elapsed;

            while (lag >= MS_PER_UPDATE)
            {
                this.Update();
                lag -= MS_PER_UPDATE;
            }

            // render();
        }
        private void printEvent()
        {
            foreach (CreateEvent systemEvent in eventSubscriber.FetchAll())
            {
                Logger.Log.Information($"[CreateEvent]. ID: {systemEvent.ObjectId}");
            }
        }

        public void Start()
        {
            Logger.Log.Information("Hello World!");
        }

        public void Update()
        {
            gameWorld.Update();
            printEvent();
        }

        public InputListener GetInputListener()
        {
            return this.gameWorld.inputListener;
        }
    }
}
