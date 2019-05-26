using System;
using System.Linq;
using System.IO;
using System.Net;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System.Xml.Linq;

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

        public static string GetLocationPhoto(FileInfo photo)
        {
            var coordinates = ImageMetadataReader.ReadMetadata(photo.FullName).OfType<GpsDirectory>().FirstOrDefault();
            var location = coordinates?.GetGeoLocation();
            var latitude = location?.Latitude.ToString().Replace(',','.');
            var longitude = location?.Longitude.ToString().Replace(',', '.');
            if (location == null)
            {
                return null;
            }
            return longitude + "," + latitude;
        }
        public static string GetLocality(string coordinates)
        {
            WebRequest request = WebRequest.Create("https://geocode-maps.yandex.ru/1.x/?geocode=" + coordinates);
            using (WebResponse response = request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            {
                XNamespace ns = "urn:oasis:names:tc:ciq:xsdschema:xAL:2.0";
                XDocument responseDocument = XDocument.Load(responseStream);
                XElement firstLocality = responseDocument.Descendants(ns + "LocalityName").FirstOrDefault();
                return firstLocality?.Value;
            }
        }

    }
}
