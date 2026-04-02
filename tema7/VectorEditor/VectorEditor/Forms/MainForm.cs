using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using VectorEditor.Figures;
using VectorEditor.Utils;
using VectorEditor.Serialization;

namespace VectorEditor.Forms
{
    public partial class MainForm : Form
    {
        private List<Figure> _figures;
        private Figure _selectedFigure;
        private StackMemory _undoStack;
        private Point _lastMouse;
        private bool _isDragging;
        private bool _isResizing;
        private HitMarkerType _resizeMarker;
        private Rectangle _originalBounds;
        private Figure _clipboardFigure;

        public MainForm()
        {
            InitializeComponent();
            _figures = new List<Figure>();
            _undoStack = new StackMemory(10);
            _isDragging = false;
            _isResizing = false;
            _resizeMarker = HitMarkerType.None;
            _clipboardFigure = null;
            SaveState();
        }

        // ==================== СОЗДАНИЕ ФИГУР ====================

        private void AddPolygon(int sides)
        {
            SaveState();
            RegularPolygon polygon = new RegularPolygon(
                new Point(100, 100),
                new Size(100, 100),
                sides,
                new Stroke(Color.Black, (float)nudStrokeWidth.Value, System.Drawing.Drawing2D.DashStyle.Solid)
            );
            _figures.Add(polygon);
            canvas.Invalidate();
        }

        private void AddStar(int points)
        {
            SaveState();
            Star star = new Star(
                new Point(100, 100),
                new Size(100, 100),
                points,
                new Stroke(Color.Black, (float)nudStrokeWidth.Value, System.Drawing.Drawing2D.DashStyle.Solid)
            );
            _figures.Add(star);
            canvas.Invalidate();
        }

        // ==================== ОТРИСОВКА ====================

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (Figure figure in _figures)
            {
                figure.Draw(e.Graphics);
            }

            if (_selectedFigure != null)
            {
                SelectionMarker.Draw(e.Graphics, _selectedFigure.GetBounds());
            }
        }

        // ==================== ОБРАБОТКА МЫШИ ====================

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            canvas.Focus();
            _lastMouse = e.Location;

            // Проверка попадания в маркеры выделенной фигуры
            if (_selectedFigure != null)
            {
                _resizeMarker = SelectionMarker.HitTest(_selectedFigure.GetBounds(), e.Location);
                if (_resizeMarker != HitMarkerType.None)
                {
                    _isResizing = true;
                    _originalBounds = _selectedFigure.GetBounds();
                    return;
                }
            }

            // Поиск фигуры под курсором
            _selectedFigure = null;
            for (int i = _figures.Count - 1; i >= 0; i--)
            {
                if (_figures[i].IsHit(e.Location))
                {
                    _selectedFigure = _figures[i];
                    _isDragging = true;
                    break;
                }
            }

            canvas.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Растягивание за маркеры
            if (_isResizing && _selectedFigure != null)
            {
                int dx = e.X - _lastMouse.X;
                int dy = e.Y - _lastMouse.Y;

                Rectangle newBounds = _originalBounds;

                switch (_resizeMarker)
                {
                    case HitMarkerType.TopLeft:
                        newBounds = new Rectangle(
                            _originalBounds.X + dx,
                            _originalBounds.Y + dy,
                            _originalBounds.Width - dx,
                            _originalBounds.Height - dy
                        );
                        break;
                    case HitMarkerType.TopRight:
                        newBounds = new Rectangle(
                            _originalBounds.X,
                            _originalBounds.Y + dy,
                            _originalBounds.Width + dx,
                            _originalBounds.Height - dy
                        );
                        break;
                    case HitMarkerType.BottomRight:
                        newBounds = new Rectangle(
                            _originalBounds.X,
                            _originalBounds.Y,
                            _originalBounds.Width + dx,
                            _originalBounds.Height + dy
                        );
                        break;
                    case HitMarkerType.BottomLeft:
                        newBounds = new Rectangle(
                            _originalBounds.X + dx,
                            _originalBounds.Y,
                            _originalBounds.Width - dx,
                            _originalBounds.Height + dy
                        );
                        break;
                }

                if (newBounds.Width >= 20 && newBounds.Height >= 20)
                {
                    SaveState();
                    _selectedFigure.Location = newBounds.Location;
                    _selectedFigure.Size = newBounds.Size;
                    _lastMouse = e.Location;
                    _originalBounds = newBounds;
                    canvas.Invalidate();
                }
                return;
            }

            // Перетаскивание фигуры
            if (_isDragging && _selectedFigure != null)
            {
                int dx = e.X - _lastMouse.X;
                int dy = e.Y - _lastMouse.Y;
                _selectedFigure.Move(dx, dy);
                _lastMouse = e.Location;
                canvas.Invalidate();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging || _isResizing)
            {
                SaveState();
            }
            _isDragging = false;
            _isResizing = false;
        }

        // ==================== ОБРАБОТКА КЛАВИШ ====================

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (_selectedFigure == null) return;

            int step = e.Shift ? 1 : 5;
            SaveState();

            switch (e.KeyCode)
            {
                case Keys.Left:
                    _selectedFigure.Move(-step, 0);
                    break;
                case Keys.Right:
                    _selectedFigure.Move(step, 0);
                    break;
                case Keys.Up:
                    _selectedFigure.Move(0, -step);
                    break;
                case Keys.Down:
                    _selectedFigure.Move(0, step);
                    break;
                case Keys.Delete:
                    DeleteSelectedFigure();
                    break;
            }

            canvas.Invalidate();
        }

        // ==================== ОТМЕНА ДЕЙСТВИЙ ====================

        private void SaveState()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, _figures);
                _undoStack.Push(ms);
            }
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                _undoStack.Pop(ms);
                if (ms.Length > 0)
                {
                    ms.Position = 0;
                    BinaryFormatter formatter = new BinaryFormatter();
                    _figures = (List<Figure>)formatter.Deserialize(ms);
                    _selectedFigure = null;
                    canvas.Invalidate();
                }
            }
        }

        // ==================== ИЗМЕНЕНИЕ СВОЙСТВ ====================

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveState();
                    _selectedFigure.Stroke.Color = colorDialog.Color;
                    canvas.Invalidate();
                }
            }
        }

        private void NudStrokeWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                SaveState();
                _selectedFigure.Stroke.Width = (float)nudStrokeWidth.Value;
                canvas.Invalidate();
            }
        }

        // ==================== БУФЕР ОБМЕНА ====================

        private void Copy_Click(object sender, EventArgs e)
        {
            if (_selectedFigure != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, _selectedFigure);
                    ms.Position = 0;
                    _clipboardFigure = (Figure)formatter.Deserialize(ms);
                }
            }
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            Copy_Click(sender, e);
            DeleteSelectedFigure();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            if (_clipboardFigure != null)
            {
                SaveState();
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, _clipboardFigure);
                    ms.Position = 0;
                    Figure newFigure = (Figure)formatter.Deserialize(ms);
                    newFigure.Move(20, 20);
                    _figures.Add(newFigure);
                    _selectedFigure = newFigure;
                    canvas.Invalidate();
                }
            }
        }

        // ==================== УДАЛЕНИЕ ====================

        private void DeleteSelectedFigure()
        {
            if (_selectedFigure != null)
            {
                SaveState();
                _figures.Remove(_selectedFigure);
                _selectedFigure = null;
                canvas.Invalidate();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteSelectedFigure();
        }

        // ==================== ФАЙЛОВЫЕ ОПЕРАЦИИ ====================

        private void NewFile_Click(object sender, EventArgs e)
        {
            _figures.Clear();
            _selectedFigure = null;
            _undoStack.Clear();
            SaveState();
            canvas.Invalidate();
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Vector Editor Files (*.vec)|*.vec";
                saveDialog.DefaultExt = "vec";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    FileManager.SaveToFile(saveDialog.FileName, _figures);
                }
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Vector Editor Files (*.vec)|*.vec";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    _figures = FileManager.LoadFromFile(openDialog.FileName);
                    _selectedFigure = null;
                    _undoStack.Clear();
                    SaveState();
                    canvas.Invalidate();
                }
            }
        }
    }
}