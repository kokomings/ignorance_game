using GameTester.GameWorldDrawer;
using MonsterFaction;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTester
{
    public partial class TestWindow : Form
    {
        private readonly Game game = new();
        private readonly KeyBindings keyBindings;

        public TestWindow()
        {
            keyBindings = new KeyBindings(game.GetInputListener());
            this.KeyDown += (object sender, KeyEventArgs e) => { keyBindings.TestWindow_KeyDown(e.KeyCode); };
            this.KeyUp += (object sender, KeyEventArgs e) => { keyBindings.TestWindow_KeyUp(e.KeyCode); };
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void TestWindow_Load(object sender, EventArgs e)
        {
            this.panel1.Paint += new PaintEventHandler(this.TestWindow_Paint);

            GameLoop();
        }

        private async void GameLoop()
        {
            game.Start();
            while (true)
            {
                game.Update();
                FetchAllLogs();
                this.panel1.Refresh();

                await Task.Delay(8);
            }
           
        }

        private void TestWindow_Paint(object sender, PaintEventArgs e)
        {
            foreach (var testObject in game.GameWorld.GetDrawables())
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
            try
            {
                this.textBox1.AppendText($"{DateTime.Now}[Log] {log.Text}");
                this.textBox1.AppendText(Environment.NewLine);
            }
            catch (Exception ex) { }
        }
    }
}
