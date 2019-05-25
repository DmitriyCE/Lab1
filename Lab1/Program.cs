using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Консольное приложение по обработке изображений");


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите нужный вам функционал:");
                Console.ResetColor();
                Console.WriteLine("a. Переименование изображении в соответствии с датой сьемки;");
                Console.WriteLine("b. Добавления на изображение отметку, когда фото было сделано;");
                Console.WriteLine("c. Сортировка изображений по папкам по годам;");
                Console.WriteLine("d. Сортировка изображений по папкам по месту сьемки;");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Укажите соответствующую букву");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                switch (Console.ReadLine())
                {
                    case "a":
                        {
                            Console.WriteLine("Введите путь к папке с фото");
                            RenameImageByData(Console.ReadLine());
                            break;
                        }
                    case "b":
                        {
                            break;
                        }
                    case "c":
                        {
                            break;
                        }
                    case "d":
                        {
                            break;
                        }
                    case "close":
                        {
                            return;
                        }

                }
                Console.Clear();
            }
        }
        public static void RenameImageByData(string path)
        {
            var dirinfo = new DirectoryInfo(path);
            dirinfo.Create();
        }
    }
}
