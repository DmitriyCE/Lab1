using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;



namespace Lab1
{
    public class SortedPhoto: CreateDirectory
    {
        public static event ApplicationInterface.PhotoStateHandler CopyingDirectoriesCompleted;
        public static event ApplicationInterface.PhotoStateHandler SotringByLocationCompleted;
        public static void SortPhotoByYears(string path)
        {
            var createDir = new CreateDirectory();
            var pathNew = createDir.CreateDirectoryOfName(path, "PhotoSort_SortPhotoByYear");
            var dirinfo = new DirectoryInfo(path);
            var massPhoto = dirinfo.GetFiles();
            var sortPhoto = new SortedPhoto();
            foreach (var photo in massPhoto)
            {
                var datePhoto = InfoImage.ImageDate(photo).ToString("Y");
                if(Directory.Exists(pathNew+$"\\{datePhoto}")==false)
                {
                    sortPhoto.CreateDirectoryOfName(pathNew, datePhoto);   
                }
                photo.CopyTo(pathNew + $"\\{datePhoto}\\{photo.Name}", true);
            }
        }

        public override string CreateDirectoryOfName(string rootPath, string nameFolder)
        {
            Directory.CreateDirectory(rootPath + $"\\{nameFolder}");
            return rootPath + $"\\{nameFolder}";
        }
        public static async void SortPhotoByYearsAsync(string path)
        {
            Console.WriteLine("Выполняется сортировка ...");
            await Task.Run(() => SortPhotoByYears(path));
            Console.WriteLine("Сортировка завершена");
            Thread.Sleep(2000);
            ApplicationInterface.RedrawAppFunc();
            CopyingDirectoriesCompleted?.Invoke(new PhotoEventsArgs() { Message = "Фото отсортированны по датам и находятся в общей папке PhotoSort_SortPhotoByYear" });
        }

        public static void SortPhotoByLocation(string path)
        {
            var createDir = new CreateDirectory();
            var pathNew = createDir.CreateDirectoryOfName(path, "PhotoSort_SortPhotoByGeoLocation");
            var dirinfo = new DirectoryInfo(path);
            var massPhoto = dirinfo.GetFiles();
            var sortPhoto = new SortedPhoto();
            foreach (var photo in massPhoto)
            {
                var geolocation=InfoImage.GetLocationPhoto(photo);
                if (geolocation != null)
                {
                    var location = InfoImage.GetLocality(geolocation);
                    if (Directory.Exists(pathNew + $"\\{location}") == false)
                    {
                        sortPhoto.CreateDirectoryOfName(pathNew, location);
                    }
                    photo.CopyTo(pathNew + $"\\{location}\\{photo.Name}", true);
                }
                else
                {
                    if (Directory.Exists(pathNew + $"\\NoneGeolocation") == false)
                    {
                        sortPhoto.CreateDirectoryOfName(pathNew, "NoneGeolocation");
                    }
                    photo.CopyTo(pathNew + $"\\NoneGeolocation\\{photo.Name}", true);
                }
            }
        }

        public static async void SortPhotoByLocationAsync(string path)
        {
            Console.WriteLine("Выполняется сортировка по геолокации ...");
            await Task.Run(() => SortPhotoByLocation(path));
            Console.WriteLine("Сортировка завершена");
            Thread.Sleep(2000);
            ApplicationInterface.RedrawAppFunc();
            SotringByLocationCompleted?.Invoke(new PhotoEventsArgs() { Message = "Фото отсортированны по геолокации и находятся в общей папке PhotoSort_SortPhotoByGeoLocation" });
        }
    }
    
}
