using System;
using System.Collections.Generic;
using System.Drawing;
using VectorEditor.Utils;

namespace VectorEditor.Figures
{
    /// <summary>
    /// Равносторонний N-угольник
    /// </summary>
    [Serializable]
    public class RegularPolygon : Figure
    {
        /// <summary>
        /// Количество сторон
        /// </summary>
        public int Sides { get; set; }

        public RegularPolygon(Point location, Size size, int sides, Stroke stroke)
            : base(location, size, stroke)
        {
            Sides = sides < 3 ? 3 : sides;
        }

        public override void Draw(Graphics g)
        {
            Point[] points = GetVertices();
            using (Pen pen = Stroke.GetPen())
            {
                g.DrawPolygon(pen, points);
            }
        }

        public override bool IsHit(Point point)
        {
            return GetBounds().Contains(point);
        }

        private Point[] GetVertices()
        {
            Point center = new Point(
                Location.X + Size.Width / 2,
                Location.Y + Size.Height / 2
            );
            float radius = Math.Min(Size.Width, Size.Height) / 2;
            List<Point> points = new List<Point>();

            for (int i = 0; i < Sides; i++)
            {
                float angle = -90 * (float)Math.PI / 180 + 2 * (float)Math.PI * i / Sides;
                int x = (int)(center.X + radius * Math.Cos(angle));
                int y = (int)(center.Y + radius * Math.Sin(angle));
                points.Add(new Point(x, y));
            }

            return points.ToArray();
        }
    }
}