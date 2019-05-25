using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    public static class InfoImage
    {
        public static DateTime ImageDate(FileInfo photo)
        {
            var fileinfo = new FileInfo(photo.FullName);
            DateTime photoDate;
            if (fileinfo?.LastWriteTime is null)
            {
                photoDate = fileinfo.CreationTime;
            }
            else
            {
                photoDate = fileinfo.LastWriteTime;
            }
            return photoDate;
        }
    }
}
