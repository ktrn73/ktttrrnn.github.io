using System;
using System.Drawing;
using VectorEditor.Utils;

namespace VectorEditor.Figures
{
    /// <summary>
    /// Базовый класс «Фигура»
    /// </summary>
    [Serializable]
    public abstract class Figure
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        protected Figure(Point location, Size size, Stroke stroke)
        {
            Location = location;
            Size = size;
            Stroke = stroke ?? new Stroke();
            IsSelected = false;
        }

        /// <summary>
        /// Верхний левый угол прямоугольной области
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Размер прямоугольной области
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Контур фигуры
        /// </summary>
        public Stroke Stroke { get; set; }

        /// <summary>
        /// Флаг выделения фигуры
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Прорисовка фигуры
        /// </summary>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Проверка попадания точки в фигуру
        /// </summary>
        public abstract bool IsHit(Point point);

        /// <summary>
        /// Сдвиг фигуры по горизонтали и вертикали
        /// </summary>
        public void Move(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
        }

        /// <summary>
        /// Перемещение фигуры в заданную точку
        /// </summary>
        public void MoveTo(Point newLocation)
        {
            Location = newLocation;
        }

        /// <summary>
        /// Изменение размера фигуры
        /// </summary>
        public void Resize(Size newSize)
        {
            Size = newSize;
        }

        /// <summary>
        /// Получить прямоугольную область фигуры
        /// </summary>
        public Rectangle GetBounds()
        {
            return new Rectangle(Location, Size);
        }
    }
}