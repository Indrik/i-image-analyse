using System;
using System.IO;
using System.Threading.Tasks;
using Ia.Domain.Interfaces;
using Ia.Domain.Models;

namespace Ia.Business
{
    public class FileCompare : IFileCompare
    {
        private const int Width = 2560;
        private const int Height = 1440;
        private const decimal DisplayArea = Height * Width;
        
        private readonly IDirectoryReader _directoryReader;
        private readonly ICompareCalculator _compareCalculator;

        public FileCompare(
            IDirectoryReader directoryReader, 
            ICompareCalculator compareCalculator)
        {
            _directoryReader = directoryReader;
            _compareCalculator = compareCalculator;
        }

        public async Task Compare(string path, int percentOfAreaLimit, bool byOneDimension)
        {
            var images = await _directoryReader.GetFilesListAsync(path).ConfigureAwait(false);
            var baseImg = new ImageInfo
            {
                Height = Height,
                Width = Width
            };
            int i = 1;
            
            foreach (var img in images)
            {
                Console.WriteLine($"calc {i}/{images.Count}");
                
                if (_compareCalculator.IsTooSmallAsync(img, baseImg, percentOfAreaLimit, byOneDimension).Result)
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