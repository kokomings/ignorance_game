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
            GameLoop();
        }

        private async void GameLoop()
        {
            game.Start();
            while (true)
            {
                game.Update();
                Render();

                await Task.Delay(8);
            }
        }

        private void Render()
        {
            FetchAllLogs();

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
