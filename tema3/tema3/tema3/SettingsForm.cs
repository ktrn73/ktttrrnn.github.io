using System;
using System.Drawing;
using System.Windows.Forms;

namespace tema3
{
    public partial class SettingsForm : Form
    {
        // Свойства для доступа к выбранным значениям
        public Color SelectedColor { get; private set; }
        public int SpeedValue { get; private set; }

        // Конструктор с параметрами
        public SettingsForm(Color currentColor, int currentSpeed)
        {
            InitializeComponent();
            SelectedColor = currentColor;
            SpeedValue = currentSpeed;

            // Устанавливаем значения в элементах управления
            trackBarSpeed.Value = SpeedValue;
            btnSelectColor.BackColor = SelectedColor;
        }

        // Выбор цвета
        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = SelectedColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectedColor = colorDialog1.Color;
                btnSelectColor.BackColor = SelectedColor;
            }
        }

        // Изменение скорости
        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            SpeedValue = trackBarSpeed.Value;
        }

        // Сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}