using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Ia.Domain.Interfaces;
using Ia.Domain.Models;

namespace Ia.Dao
{
    public class DirectoryReader : IDirectoryReader
    {
        public async Task<List<ImageInfo>> GetFilesList(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException(directory);
            }
            
            var result = new List<ImageInfo>();
            
            var filesList = Directory.GetFiles(directory);
            foreach (var file in filesList)
            {
                if (!File.Exists(file))
                {
                    throw new FileNotFoundException(file);
                }

                var imageInfo = new ImageInfo(directory, file);
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