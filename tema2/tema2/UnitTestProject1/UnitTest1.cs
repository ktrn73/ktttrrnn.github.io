using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using tema2; // Ссылка на тестируемый проект

namespace UnitTestProject
{
    [TestClass]
    public class GeometryLogicTests
    {
        // Тест 1: Список из 2 точек (Успешный)
        [TestMethod]
        public void FindClosestPairs_TwoPoints_ReturnsOnePair()
        {
            // Arrange
            var points = new List<Point> { new Point(0, 0), new Point(3, 4) };
            double expectedDistance = 5.0;

            // Act
            var result = GeometryLogic.FindClosestPairs(points);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(expectedDistance, result[0].distance, 1e-10);
        }

        // Тест 2: Точки с дубликатами (Успешный)
        [TestMethod]
        public void FindClosestPairs_WithDuplicates_ReturnsZeroDistance()
        {
            // Arrange
            var points = new List<Point> { new Point(0, 0), new Point(1, 1), new Point(5, 2), new Point(1, 1) };

            // Act
            var result = GeometryLogic.FindClosestPairs(points);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result[0].distance, 1e-10);
            Assert.IsTrue((result[0].p1.Equals(new Point(1, 1)) && result[0].p2.Equals(new Point(1, 1))));
        }

        // Тест 3: Несколько пар с одинаковым мин. расстоянием (Успешный)
        [TestMethod]
        public void FindClosestPairs_MultipleMinimalPairs_ReturnsAllPairs()
        {
            // Arrange
            var points = new List<Point> { new Point(0, 0), new Point(2, 0), new Point(1, 1), new Point(1, -1) };
            double expectedMinDistance = Math.Sqrt(2); // ~1.414

            // Act
            var result = GeometryLogic.FindClosestPairs(points);

            // Assert
            Assert.AreEqual(2, result.Count);
            foreach (var pair in result)
            {
                Assert.AreEqual(expectedMinDistance, pair.distance, 1e-10);
            }
        }

        // Тест 4: Граничное условие: меньше двух точек (1 точка)
        [TestMethod]
        public void FindClosestPairs_SinglePoint_ReturnsEmptyList()
        {
            // Arrange
            var points = new List<Point> { new Point(5, 5) };

            // Act
            var result = GeometryLogic.FindClosestPairs(points);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        // Тест 5: Граничное условие: пустой список
        [TestMethod]
        public void FindClosestPairs_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var points = new List<Point>();

            // Act
            var result = GeometryLogic.FindClosestPairs(points);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        // Тест 6: Негативный тест: null вместо списка (Ожидается исключение)
        [TestMethod]
        public void FindClosestPairs_NullInput_ThrowsArgumentException()
        {
            // Arrange
            List<Point> points = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => GeometryLogic.FindClosestPairs(points));
        }
    }
}