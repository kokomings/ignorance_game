using System.Threading.Tasks;

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
                GameLoop(game);
            }
        }

        private static async void GameLoop(Game game)
        {
            game.Update();
            // To-do: Tester와 형식을 맞추기 위해 이렇게 했고 나중에 변경해야 함.
            await Task.Delay(8);
        }
    }

    public class Game
    {
        public void Start()
        {
            Logger.Log.Information("Hello World!");
        }

        public void Update()
        {
            Logger.Log.Information("Hi!");
        }

    }
}
