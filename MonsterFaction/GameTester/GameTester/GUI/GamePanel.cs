using System.Windows.Forms;

namespace GameTester.GUI
{
    public class GamePanel : Panel
    {
        public GamePanel()
        {
            // 화면 깜빡임 제거
            this.DoubleBuffered = true;
        }
    }
}
