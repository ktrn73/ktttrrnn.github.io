using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditor.Utils
{
    /// <summary>
    /// Класс для хранения свойств контура фигуры
    /// </summary>
    [Serializable]
    public class Stroke
    {
        /// <summary>
        /// Конструктор без параметров, со свойствами по умолчанию
        /// </summary>
        public Stroke()
        {
            Color = Color.Black;
            Width = 2f;
            DashStyle = DashStyle.Solid;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Stroke(Color color, float width, DashStyle dashStyle)
        {
            Color = color;
            Width = width;
            DashStyle = dashStyle;
        }

        /// <summary>
        /// Цвет линии фигуры
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Ширина линии фигуры
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Стиль линии фигуры
        /// </summary>
        public DashStyle DashStyle { get; set; }

        /// <summary>
        /// Свойство возвращает "карандаш", настроенный по текущим свойствам
        /// </summary>
        public Pen GetPen()
        {
            return new Pen(Color, Width) { DashStyle = DashStyle };
        }
    }
}