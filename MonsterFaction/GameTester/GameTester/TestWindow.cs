using GameTester.GameWorldDrawer;
using MonsterFaction;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTester
{
    public partial class TestWindow : Form, IMessageFilter
    {
        private readonly Game game = new();

        public TestWindow()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
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

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == KeyBindings.WM_KEYDOWN || m.Msg == KeyBindings.WM_KEYUP)
            {
                KeyBindings.KeyEvent(ref m, (Keys)m.WParam.ToInt32());
            }

            return false;
        }
    }
}
