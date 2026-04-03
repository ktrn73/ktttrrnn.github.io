using System;
using System.Windows.Forms;

namespace Puzzle15Game
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Показываем форму авторизации
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Если логин введён успешно, запускаем главную форму
                Application.Run(new Form1());
            }
            else
            {
                // Если пользователь нажал Отмена или закрыл окно — выходим
                Application.Exit();
            }
        }
    }
}