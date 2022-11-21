using GameTester.GameWorldDrawer;
using MonsterFaction;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTester
{
    public partial class TestWindow : Form
    {
        private readonly Game game = new();

        public TestWindow()
        {
            InitializeComponent();
        }

        private void TestWindow_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(this.TestWindow_Paint);
            GameLoop();
        }

        private async void GameLoop()
        {
            game.Start();
            while (true)
            {
                game.Update();
                FetchAllLogs();

                await Task.Delay(8);
            }
        }

        private void TestWindow_Paint(object sender, PaintEventArgs e)
        {
            foreach (var testObject in game.GameWorld.GetTestObjects())
            {
                GameObjectDrawer.DrawGameObject(e, testObject);
            }
        }

        private void FetchAllLogs()
        {
            if (Logger.Log.occurredLogs.Count > 0)
            {
                foreach (var log in Logger.Log.occurredLogs)
                {
                    this.PrintLog(log);
                }
                Logger.Log.occurredLogs.Clear();
            }
        }

        private void PrintLog(Log log)
        {
            this.textBox1.AppendText($"{DateTime.Now}[Log] {log.Text}");
            this.textBox1.AppendText(Environment.NewLine);
        }
    }
}
