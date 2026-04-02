using System;
using System.Collections.Generic;
using System.Drawing;
using VectorEditor.Utils;

namespace VectorEditor.Figures
{
    /// <summary>
    /// Звезда
    /// </summary>
    [Serializable]
    public class Star : Figure
    {
        /// <summary>
        /// Количество лучей
        /// </summary>
        public int Points { get; set; }

        public Star(Point location, Size size, int points, Stroke stroke)
            : base(location, size, stroke)
        {
            Points = points < 3 ? 3 : points;
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
            float outerR = Math.Min(Size.Width, Size.Height) / 2;
            float innerR = outerR / 2.5f;
            List<Point> points = new List<Point>();

            for (int i = 0; i < Points * 2; i++)
            {
                float angle = -90 * (float)Math.PI / 180 + (float)Math.PI * i / Points;
                float r = (i % 2 == 0) ? outerR : innerR;
                int x = (int)(center.X + r * Math.Cos(angle));
                int y = (int)(center.Y + r * Math.Sin(angle));
                points.Add(new Point(x, y));
            }

            return points.ToArray();
        }
    }
}