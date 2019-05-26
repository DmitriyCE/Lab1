using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    public class RenameImage
    {
        public static event ApplicationInterface.PhotoStateHandler PhotoCopyCompleted;
        public static void RenameImageByData(string path)
        {
            var createDir = new CreateDirectory();
            var pathNew = createDir.CreateDirectoryOfName(path, "PhotoDate_RenameImage");
            var dirinfo = new DirectoryInfo(path);
            var massPhoto = dirinfo.GetFiles();
            foreach (var photo in massPhoto)
            {
                photo.CopyTo(pathNew + $"\\{photo.Name.Split('.')[0]}_{InfoImage.ImageDate(photo).ToShortDateString()}.{photo.Name.Split('.')[1]}", true);
            }

        }
        public static async void RenameImageByDataAsync(string path)
        {
            Console.WriteLine("Выполняется копирование ...");
            Thread.Sleep(1000);
            await Task.Run(() => RenameImageByData(path));
            Console.WriteLine("Копирование завершено");
            Thread.Sleep(3000);
            ApplicationInterface.RedrawAppFunc();
            PhotoCopyCompleted(new PhotoEventsArgs() { Message = "Фото переименованы и скопированы в папку PhotoDate_RenameImage" });
        }
    }
}
