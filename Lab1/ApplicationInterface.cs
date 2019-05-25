using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab1
{
    public static class ApplicationInterface
    {
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
            WriteLine("Введите путь к папке с изображениями");
            return @"d:\Рабочая папка\CS\ДЗ\Lab\foto\";//ReadLine();
        }
    }
}
