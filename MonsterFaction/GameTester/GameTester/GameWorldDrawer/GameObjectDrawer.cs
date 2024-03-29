﻿using MonsterFaction;
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

            if (gameObject.Shape is SquareShape)
            {
                DrawRect(e);
            }
            else if (gameObject.Shape is CircleShape)
            {
                DrawCircle(e);
            }
        }

        private static void DrawCircle(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(blueBrush, rect);
        }

        private static void DrawRect(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(blackPen, rect);
        }
        private static void DecideRect(IDrawable gameObject)
        {
            // 우측으로 갈수록 x가 증가하고 위로 갈수록 y가 증가한다.
            // TODO: rect 를 double 로 쓰게하자.
            rect.Width = (float)gameObject.Shape.Width;
            rect.Height = (float)gameObject.Shape.Height;
            rect.X = (float)gameObject.Center.X - (float)gameObject.Shape.Width / 2; // 충돌 좌표계와 위치 맞춤.
            rect.Y = -(float)gameObject.Center.Y - (float)gameObject.Shape.Height / 2 + 330; // 0,0 좌표를 로그칸 바로 위로 맞추느라 조정.
        }
    }
}
