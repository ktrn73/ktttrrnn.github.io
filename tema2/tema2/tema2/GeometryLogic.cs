using System;
using System.Collections.Generic;
using System.Linq;

namespace tema2
{
    /// <summary>
    /// Класс, содержащий методы для геометрических вычислений.
    /// </summary>
    public static class GeometryLogic
    {
        /// <summary>
        /// Проверяет, являются ли входные строки корректными числами с плавающей точкой.
        /// </summary>
        private static bool IsValidCoordinate(string coord, out double value)
        {
            return double.TryParse(coord.Replace('.', ','), out value); // Замена точки на запятую для культуры
        }

        /// <summary>
        /// Вычисляет расстояние между двумя точками.
        /// </summary>
        /// <param name="p1">Первая точка.</param>
        /// <param name="p2">Вторая точка.</param>
        /// <returns>Расстояние между точками.</returns>
        public static double CalculateDistance(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Находит все пары точек с минимальным расстоянием в заданном списке.
        /// </summary>
        /// <param name="points">Список точек.</param>
        /// <returns>
        /// Список кортежей, содержащий пары точек и расстояние между ними.
        /// Если точек меньше 2, возвращает пустой список.
        /// </returns>
        /// <exception cref="ArgumentException">Выбрасывается, если список точек равен null.</exception>
        public static List<(Point p1, Point p2, double distance)> FindClosestPairs(List<Point> points)
        {
            if (points == null)
            {
                throw new ArgumentException("Список точек не может быть null.");
            }

            if (points.Count < 2)
            {
                return new List<(Point, Point, double)>();
            }

            double minDistance = double.MaxValue;
            List<(Point, Point, double)> closestPairs = new List<(Point, Point, double)>();

            // Перебор всех возможных уникальных пар
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    double dist = CalculateDistance(points[i], points[j]);

                    // Если нашли новое минимальное расстояние
                    if (dist < minDistance - 1e-10) // Используем эпсилон для сравнения double
                    {
                        minDistance = dist;
                        closestPairs.Clear();
                        closestPairs.Add((points[i], points[j], dist));
                    }
                    // Если расстояние равно текущему минимальному (в пределах погрешности)
                    else if (Math.Abs(dist - minDistance) < 1e-10)
                    {
                        closestPairs.Add((points[i], points[j], dist));
                    }
                }
            }

            return closestPairs;
        }

        /// <summary>
        /// Вспомогательный метод для парсинга строки с координатами в точку.
        /// Формат строки: "x y"
        /// </summary>
        public static bool TryParsePoint(string input, out Point point)
        {
            point = new Point(0, 0);
            var parts = input.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && IsValidCoordinate(parts[0], out double x) && IsValidCoordinate(parts[1], out double y))
            {
                point = new Point(x, y);
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Простая структура для представления точки на плоскости.
    /// </summary>
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X:F2}; {Y:F2})";
        }
    }
}