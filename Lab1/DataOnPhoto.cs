using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Lab1
{
    public class DataOnPhoto
    {
        public static event ApplicationInterface.PhotoStateHandler PhotoDrawingCompleted;
        public static void DateOnTheImage(string path)
        {
            var createDir = new CreateDirectory();
            var pathNew = createDir.CreateDirectoryOfName(path, "Photo_DateOnTheImage");
            var dirinfo = new DirectoryInfo(path);
            var massPhoto = dirinfo.GetFiles();

            foreach (var photo in massPhoto)
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(photo.FullName);
                int wight = bitmap.Width;
                int height = bitmap.Height;
                PointF TextLocation = new PointF(wight - 500, 200);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Arial", 80, FontStyle.Bold))
                    {
                        graphics.DrawString(InfoImage.ImageDate(photo).ToShortDateString(), arialFont, Brushes.Red, TextLocation);
                    }
                }
                bitmap.Save(pathNew + $"\\{photo.Name}");
            }
        }
        public static async void DateOnTheImageAsync(string path)
        {
            Console.WriteLine("Выполнение программы ...");
            await Task.Run(()=> DateOnTheImage(path));
            Console.WriteLine("Работа над изображениями завершена.");
            Thread.Sleep(2000);
            ApplicationInterface.RedrawAppFunc();
            PhotoDrawingCompleted(new PhotoEventsArgs() { Message = "На изображения нанесена дата съёмки и скопированы в папку Photo_DateOnTheImage" });
        }
    }
}
