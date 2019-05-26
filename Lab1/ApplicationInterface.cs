using System;
using System.Threading;
using System.Windows.Forms;
using static System.Console;

namespace Lab1
{
    public static class ApplicationInterface
    {
        public delegate void PhotoStateHandler(PhotoEventsArgs args);
        public static void AppFunc()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Консольное приложение по обработке изображений");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Выберите нужный вам функционал:");
            ResetColor();
            WriteLine("a. Переименование изображении в соответствии с датой сьемки;");
            WriteLine("b. Добавления на изображение отметку, когда фото было сделано;");
            WriteLine("c. Сортировка изображений по папкам по годам;");
            WriteLine("d. Сортировка изображений по папкам по месту сьемки;");
            WriteLine(" Для выхода нажмите Esc");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Нажмите соответсвующую клавишу");
            ForegroundColor = ConsoleColor.Gray;
        }
        public static void RedrawAppFunc()
        {
            Clear();
            AppFunc();
        }
        public static string PathRequest()
        {
            WriteLine("Выберите путь к папке с изображениями");

            string path = null;
            Thread thread = new Thread(() =>
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        path = fbd.SelectedPath;
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return path;


            //return @"i:\CS\Labs\photo1\";//ReadLine();
        }
    }
}
