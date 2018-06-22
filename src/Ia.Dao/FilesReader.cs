using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Ia.Domain.Interfaces;
using Ia.Domain.Models;

namespace Ia.Dao
{
    public class FilesReader : IFilesReader
    {
        public async Task<List<ImageInfo>> GetDirectoryFilesAsync(string[] filesList)
        {
            var result = new List<ImageInfo>();
            
            foreach (var file in filesList)
            {
                if (!File.Exists(file))
                {
                    throw new FileNotFoundException(file);
                }

                var imageInfo = new ImageInfo(file, Path.GetFileName(file));
                using (var image = Image.FromFile(file))
                {
                    imageInfo.Height = image.Height;
                    imageInfo.Width = image.Width;
                }
                result.Add(imageInfo);
            }

            return result;
        }
    }
}