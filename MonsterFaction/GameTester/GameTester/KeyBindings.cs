using MonsterFaction;
using System.Windows.Forms;

namespace GameTester
{
    public static class KeyBindings
    {
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;

        public static void KeyEvent(ref Message msg, Keys keyData)
        {
            if (msg.Msg == WM_KEYDOWN)
            {
                TestWindow_KeyDown(keyData);
            }
            else if (msg.Msg == WM_KEYUP)
            {
                TestWindow_KeyUp(keyData);
            }
        }

        private static void TestWindow_KeyDown(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    InputListener.Input.UpButton_Down();
                    break;
                case Keys.S:
                    InputListener.Input.DownButton_Down();
                    break;
                case Keys.A:
                    InputListener.Input.LeftButton_Down();
                    break;
                case Keys.D:
                    InputListener.Input.RightButton_Down();
                    break;
                case Keys.ShiftKey:
                    InputListener.Input.Acceleration_Down();
                    break;
                case Keys.J:
                    InputListener.Input.Attack_Down();
                    break;
            }
        }
        private static void TestWindow_KeyUp(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    InputListener.Input.UpButton_Up();
                    break;
                case Keys.S:
                    InputListener.Input.DownButton_Up();
                    break;
                case Keys.A:
                    InputListener.Input.LeftButton_Up();
                    break;
                case Keys.D:
                    InputListener.Input.RightButton_Up();
                    break;
                case Keys.ShiftKey:
                    InputListener.Input.Acceleration_Up();
                    break;
            }
        }
    }
}
