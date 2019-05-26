using System.IO;

namespace Lab1
{
    public class CreateDirectory
    {
        public virtual string CreateDirectoryOfName(string photoPath, string nameFolder)
        {
            var photoDirInfo = new DirectoryInfo(photoPath);
            var rootPath = photoDirInfo.Parent.FullName;
            Directory.CreateDirectory(rootPath + $"\\{nameFolder}");
            return rootPath + $"\\{nameFolder}";
        }
    }
}
