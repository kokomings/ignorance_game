using Microsoft.VisualBasic.Devices;
using MonsterFaction;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using System;
using System.Windows.Forms;

namespace GameTester
{
    public class KeyBindings
    {
        private readonly InputListener inputListener;
        public KeyBindings(InputListener inputListener) 
        { 
            this.inputListener = inputListener;
        }
        public void TestWindow_KeyDown(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    inputListener.UpButton_Down();
                    break;
                case Keys.S:
                    inputListener.DownButton_Down();
                    break;
                case Keys.A:
                    inputListener.LeftButton_Down();
                    break;
                case Keys.D:
                    inputListener.RightButton_Down();
                    break;
                case Keys.ShiftKey:
                    inputListener.Acceleration_Down();
                    break;
                case Keys.J:
                    inputListener.Attack_Down();
                    break;
            }
        }
        public void TestWindow_KeyUp(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    inputListener.UpButton_Up();
                    break;
                case Keys.S:
                    inputListener.DownButton_Up();
                    break;
                case Keys.A:
                    inputListener.LeftButton_Up();
                    break;
                case Keys.D:
                    inputListener.RightButton_Up();
                    break;
                case Keys.ShiftKey:
                    inputListener.Acceleration_Up();
                    break;
            }
        }
    }
}
