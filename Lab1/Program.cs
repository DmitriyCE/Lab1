using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationInterface.AppFunc();
            while (true)
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.A:
                        {
                            ApplicationInterface.RedrawAppFunc();
                            RenameImageByData(ApplicationInterface.PathRequest());
                            break;
                        }
                    case ConsoleKey.B:
                        {
                            ApplicationInterface.RedrawAppFunc();
                            MarkOnTheImage(ApplicationInterface.PathRequest());
                            break;
                        }
                    case ConsoleKey.C:
                        {
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }
        }
        public static void RenameImageByData(string path)
        {
            var pathNew = CreateDirectoryOfName(path, "PhotoDate_RenameImage");
            var dirinfo = new DirectoryInfo(path);
            var massPhoto = dirinfo.GetFiles();
            foreach (var photo in massPhoto)
            {
                photo.CopyTo(pathNew + $"\\{photo.Name.Split('.')[0]}_{InfoImage.ImageDate(photo).ToShortDateString()}.{photo.Name.Split('.')[1]}", true);
            }
            WriteLine("Фото переименованы и скопированы в папку PhotoDate_RenameImage");
        }
        public static void MarkOnTheImage(string path)
        {
            var pathNew = CreateDirectoryOfName(path, "Photo_MarkOnTheImage");
            var dirinfo = new DirectoryInfo(path);
            var massPhoto = dirinfo.GetFiles();
            
            foreach (var photo in massPhoto)
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(photo.FullName);
                int wight = bitmap.Width;
                int height = bitmap.Height;
                PointF TextLocation = new PointF(wight -500, 200);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Arial", 80, FontStyle.Bold))
                    {
                        graphics.DrawString(InfoImage.ImageDate(photo).ToShortDateString(), arialFont, Brushes.Red, TextLocation);
                    }
                }
                bitmap.Save(pathNew +$"\\{photo.Name}");
            }
            WriteLine("На все изображения из каталога проставлена дата съёмки");

        }
        public static string CreateDirectoryOfName(string path,string nameDirect)
        {
            var dirinfo = new DirectoryInfo(path);
            var pathNew = dirinfo.Parent.FullName;
            Directory.CreateDirectory(pathNew + $"\\{nameDirect}");
            return pathNew + $"\\{nameDirect}";
        }





    }
}
