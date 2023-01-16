using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace Geocoding_App
{
    class Functions
    {

        public static bool StartProcess(string[] lista, BackgroundWorker worker)
        {
            int amountSucceded = 0;
            int amountFailed = 0;

            foreach (var i in lista)
            {
                if (!worker.CancellationPending)
                {
                    Image image = Image.FromFile(i);

                    var splited = i.Split(Path.DirectorySeparatorChar);
                    var nameImage = splited[splited.Length - 1];
                    int type;
                    try
                    {
                        double latitude = GetCoordinateDouble(image.GetPropertyItem(2), image.GetPropertyItem(1));
                        double longitude = GetCoordinateDouble(image.GetPropertyItem(4), image.GetPropertyItem(3));
                        
                        image.Dispose();

                        var resultAddress = GetAddressFromPointAsync(latitude.ToString(), longitude.ToString());

                        if (resultAddress.error != null)
                            throw new Exception();

                        MoveImageToDestination(resultAddress, i, nameImage);

                        type = 15;
                        amountSucceded++;
                    }
                    catch (Exception)
                    {
                        type = 14;
                        amountFailed++;
                    }

                    worker.ReportProgress(1, Config.languagesPhrases[type, Config.languageSelected] + "|" + nameImage + "\n");
                }
                else
                {
                    break;
                }
            }

            worker.ReportProgress(0, "\n" + Config.languagesPhrases[16, Config.languageSelected] + amountFailed + "\n");
            worker.ReportProgress(0, Config.languagesPhrases[17, Config.languageSelected] + amountSucceded + "\n");

            if (!worker.CancellationPending)
            {
                return false;
            }
            return true;
        }

        private static void MoveImageToDestination(RootObject rootObject, string pathOfImage, string nameImage)
        {

            if(Directory.Exists(Config.pathFrom) && Directory.Exists(Config.pathTo))
            {
                var newPath = Config.pathTo;
                if (Config.country)
                {
                    newPath += Path.DirectorySeparatorChar + rootObject.address.country;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }
                if (Config.state)
                {
                    newPath += Path.DirectorySeparatorChar + rootObject.address.state;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }
                if (Config.city && rootObject.address.city != null)
                {
                    newPath += Path.DirectorySeparatorChar + rootObject.address.city;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }
                if (Config.city && rootObject.address.village != null)
                {
                    newPath += Path.DirectorySeparatorChar + rootObject.address.village;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }
                newPath += Path.DirectorySeparatorChar + nameImage;
                
                File.Move(pathOfImage, newPath);
            }

        }

        public static string[] LoadImages()
        {
            var extensions = new string[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var listFiles = GetFilesFrom(Config.pathFrom, extensions);
            return listFiles;
        }

        private static RootObject GetAddressFromPointAsync(string lat, string lon)
        {

            HttpClient h = new HttpClient();

            h.DefaultRequestHeaders.Add("User-Agent", Config.user_agent);

            var query = new Dictionary<string, string>()
            {
                ["format"] = Config.format,
                ["lat"] = lat.Replace(',','.'),
                ["lon"] = lon.Replace(',', '.'),
                ["zoom"] = Config.zoom,
                ["accept-language"] = GetLanguageByName()
            };

            var uri = QueryHelpers.AddQueryString(Config.url, query);
            
            Task<string> request;

            request = h.GetStringAsync(uri);

            request.Wait();

            var result = JsonConvert.DeserializeObject<RootObject>(request.Result);

            return result;
        }

        private static string[] GetFilesFrom(string searchFolder, string[] filters)
        {
            List<string> filesFound = new List<string>();
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, string.Format("*.{0}", filter)));
            }
            return filesFound.ToArray();
        }

        private static string GetLanguageByName()
        {
            switch(Config.languageSelected)
            {
                case 0:
                    return "en-US";
                case 1:
                    return "es-ES";
                case 2:
                    return "da";
                default:
                    return "en-US";
            }
        }

        private static double GetCoordinateDouble(PropertyItem propItem, PropertyItem propItemRef)
        {
            uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;

            double coord = degrees + (minutes / 60d) + (seconds / 3600d);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] });

            if (gpsRef == "S" || gpsRef == "W")
            {
                coord *= -1;
            }

            return coord;
        }

    }
}
