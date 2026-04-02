using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditor.Utils
{
    /// <summary>
    /// Класс обрамления фигуры при её выделении
    /// </summary>
    public static class SelectionMarker
    {
        private const int MarkerSize = 7;

        /// <summary>
        /// Отрисовка маркеров по краям прямоугольной области фигуры
        /// </summary>
        public static void Draw(Graphics g, Rectangle rect)
        {
            // Рамка выделения
            using (Pen pen = new Pen(Color.Blue, 2) { DashStyle = DashStyle.DashDot })
            {
                g.DrawRectangle(pen, rect);
            }

            // Маркеры по углам
            Point[] markers = new Point[]
            {
                new Point(rect.Left - MarkerSize / 2, rect.Top - MarkerSize / 2),
                new Point(rect.Right - MarkerSize / 2, rect.Top - MarkerSize / 2),
                new Point(rect.Right - MarkerSize / 2, rect.Bottom - MarkerSize / 2),
                new Point(rect.Left - MarkerSize / 2, rect.Bottom - MarkerSize / 2)
            };

            foreach (Point marker in markers)
            {
                g.FillRectangle(Brushes.White, marker.X, marker.Y, MarkerSize, MarkerSize);
                g.DrawRectangle(Pens.Black, marker.X, marker.Y, MarkerSize, MarkerSize);
            }
        }

        /// <summary>
        /// Проверка попадания в маркер
        /// </summary>
        public static HitMarkerType HitTest(Rectangle rect, Point point)
        {
            Rectangle topLeft = new Rectangle(rect.Left - MarkerSize / 2, rect.Top - MarkerSize / 2, MarkerSize, MarkerSize);
            Rectangle topRight = new Rectangle(rect.Right - MarkerSize / 2, rect.Top - MarkerSize / 2, MarkerSize, MarkerSize);
            Rectangle bottomRight = new Rectangle(rect.Right - MarkerSize / 2, rect.Bottom - MarkerSize / 2, MarkerSize, MarkerSize);
            Rectangle bottomLeft = new Rectangle(rect.Left - MarkerSize / 2, rect.Bottom - MarkerSize / 2, MarkerSize, MarkerSize);

            if (topLeft.Contains(point)) return HitMarkerType.TopLeft;
            if (topRight.Contains(point)) return HitMarkerType.TopRight;
            if (bottomRight.Contains(point)) return HitMarkerType.BottomRight;
            if (bottomLeft.Contains(point)) return HitMarkerType.BottomLeft;

            return HitMarkerType.None;
        }
    }

    /// <summary>
    /// Типы маркеров
    /// </summary>
    public enum HitMarkerType
    {
        None,
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft
    }
}