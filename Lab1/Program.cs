using System;
using static System.Console;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            RenameImage.PhotoCopyCompleted += (e) => { WriteLine(e.Message); };
            DataOnPhoto.PhotoDrawingCompleted += (e) => { WriteLine(e.Message); };
            SortedPhoto.CopyingDirectoriesCompleted += (e) => { WriteLine(e.Message); };
            SortedPhoto.SotringByLocationCompleted += (e) => { WriteLine(e.Message); };
            ApplicationInterface.AppFunc();
            while (true)
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.A:
                        {
                            ApplicationInterface.RedrawAppFunc();
                            RenameImage.RenameImageByDataAsync(ApplicationInterface.PathRequest());
                            break;
                        }
                    case ConsoleKey.B:
                        {
                            ApplicationInterface.RedrawAppFunc();
                            DataOnPhoto.DateOnTheImageAsync(ApplicationInterface.PathRequest());
                            break;
                        }
                    case ConsoleKey.C:
                        {
                            ApplicationInterface.RedrawAppFunc();
                            SortedPhoto.SortPhotoByYearsAsync(ApplicationInterface.PathRequest());
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            ApplicationInterface.RedrawAppFunc();
                            SortedPhoto.SortPhotoByLocationAsync(ApplicationInterface.PathRequest());
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }
        }

    }
}
