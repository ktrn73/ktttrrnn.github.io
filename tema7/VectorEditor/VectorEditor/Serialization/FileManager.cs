using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using VectorEditor.Figures;

namespace VectorEditor.Serialization
{
    /// <summary>
    /// Класс для сохранения и загрузки фигур
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Сохранить все фигуры в файл
        /// </summary>
        public static void SaveToFile(string path, List<Figure> figures)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    formatter.Serialize(fs, figures);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузить фигуры из файла
        /// </summary>
        public static List<Figure> LoadFromFile(string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    return (List<Figure>)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Figure>();
            }
        }
    }
}