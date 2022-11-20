using MonsterFaction.GameWorld.WorldObject;
using MonsterFaction.GameWorld.WorldObject.Shape;
using System.Drawing;
using System.Windows.Forms;

namespace GameTester.GameWorldDrawer
{
    public class GameObjectDrawer
    {
        private static readonly Pen blackPen = new(Color.Black, 1);
        private static readonly SolidBrush blueBrush = new(Color.Blue);
        private static RectangleF rect = new();

        public static void DrawGameObject(PaintEventArgs e, IDrawable gameObject)
        {
            DecideRect(gameObject);

            if (gameObject.Shape is BoxShape)
            {
                DrawRect(e);
            }
            else if (gameObject.Shape is SphereShape)
            {
                DrawSphere(e);
            }
        }

        private static void DrawSphere(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(blueBrush, rect);
        }

        private static void DrawRect(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(blackPen, rect);
        }

        private static void DecideRect(IDrawable gameObject)
        {
            // 유니티의 왼손좌표계 이용, 위에서 내려다봤을 때
            // 우측으로 갈수록 x가 증가하고 위로 갈수록 z가 증가한다.
            rect.Width = gameObject.Shape.Size.X;
            rect.Height = gameObject.Shape.Size.Z;
            rect.X = gameObject.Position.X - gameObject.Shape.Center.X;
            rect.Y = -gameObject.Position.Z - gameObject.Shape.Center.Z;
        }
    }
}
