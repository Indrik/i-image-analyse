using System;
using System.IO;
using System.Threading.Tasks;
using Ia.Domain.Interfaces;

namespace Ia.Business
{
    public class FileCompare : IFileCompare
    {
        private const int Width = 2560;
        private const int Height = 1440;
        private const decimal DisplayArea = Height * Width;
        
        private readonly IDirectoryReader _directoryReader;

        public FileCompare(IDirectoryReader directoryReader)
        {
            _directoryReader = directoryReader;
        }

        public async Task Compare(string path, int percentOfAreaLimit)
        {
            var images = await _directoryReader.GetFilesListAsync(path).ConfigureAwait(false);
            int i = 1;
            
            foreach (var img in images)
            {
                Console.WriteLine($"calc {i}/{images.Count}");
                decimal area = img.Area / DisplayArea * 100;
                
                if (area < percentOfAreaLimit)
                {
                    var newPathName = $"{path}/{percentOfAreaLimit}p";
                    if (!Directory.Exists(newPathName))
                    {
                        Directory.CreateDirectory(newPathName);
                    }
                    
                    File.Move(img.Path, $"{newPathName}/{img.Name}");
                }

                i++;
            }
        }
    }
}