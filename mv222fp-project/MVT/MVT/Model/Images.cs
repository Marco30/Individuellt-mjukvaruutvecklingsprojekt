using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVT.Model
{
    public class Images
    {
        /// <summary>
        /// Fields
        /// </summary>
        private static readonly Regex ApprovedExtensions;
        private static string PhysicalUploadedImagesPath;
        private static string PhysicalUploadedThumbsPath;// = "Content\\Thumbs\\";
        private static readonly Regex SantizePath;

        /// <summary>
        /// Static Constructor with initialization of ReadOnly fields
        /// </summary>
        static Images()
        {
            ApprovedExtensions = new Regex(@"^.*\.(gif|jpg|png|jpeg)$");
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Images\");
            PhysicalUploadedThumbsPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Images\Thumbs\");
            SantizePath.Replace(invalidChars, "");
        }

        /// <summary>
        /// Get image names from directory, and sort images in asc order
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetImageNames()
        {

            //var imagesInDirectory = new List<string>();
            /*============================================*/
            /* Search pattern doesn´t support regex */
            /* http://stackoverflow.com/questions/163162/can-you-call-directory-getfiles-with-multiple-filters */
            /*===========================================*/

            /* var files = Directory.EnumerateFiles(PhysicalUploadedImagesPath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".gif")|| s.EndsWith(".png")).OrderBy(filename => filename).ToList();
            */
            var dir = new DirectoryInfo(PhysicalUploadedImagesPath);
            FileInfo[] images = dir.GetFiles();


            var files = images
                .Select(image => image.Name)
                .Where(filename => ApprovedExtensions.IsMatch(filename))
               .OrderBy(filename => filename)
               .ToList();

            return files.AsReadOnly();
        }
        /// <summary>
        /// Checks if File with the same name exists in folder.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ImageExists(string name)
        {
            if (File.Exists(name))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if Image is of valid type
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
            {
                return true;
            }
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
            {
                return true;
            }
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method that do all dirty work.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>

        public string SaveImage(Stream stream, string fileName)
        {
            Image image = System.Drawing.Image.FromStream(stream);
            var appPath = AppDomain.CurrentDomain.GetData("APPBASE").ToString();

            if (IsValidImage(image))
            {
                /* Code for indexing of images*/
                while (ImageExists(PhysicalUploadedImagesPath + fileName))
                {
                    char[] delimiterChars = { '.' };
                    string[] parts = fileName.Split(delimiterChars);
                    string name = parts[0];
                    Match regex = Regex.Match(name, @".*[(]?[)]$");

                    if (regex.Success)
                    {
                        int y = name.Length - 2;
                        double temp = Char.GetNumericValue(name[y]);
                        int index = Convert.ToInt32(temp);

                        parts[0] = (parts[0]).Remove(parts[0].Length - 3);
                        parts[0] = parts[0] + "(" + (index + 1) + ")";
                    }
                    else
                    {
                        parts[0] = parts[0] + "(" + 1 + ")";
                    }
                    fileName = parts[0] + "." + parts[1];
                }
                try
                {
                    string file = PhysicalUploadedImagesPath + fileName;
                    image.Save(file);
                }
                catch
                {
                    throw new Exception();
                }

                var thumbnail = image.GetThumbnailImage(180, 135, null, System.IntPtr.Zero);
                thumbnail.Save(PhysicalUploadedThumbsPath + fileName);

                return fileName;
            }
            else
            {
                throw new Exception("Filen är inte av rätt format");
            }
        }
    }
}
