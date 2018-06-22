using System.IO;
using System.Threading.Tasks;
using Ia.Domain.Interface;
using Ia.Domain.Interfaces;

namespace src
{
    public class Analyser : IAnalyser
    {
        private const int Width = 2560;
        private const int Height = 1440;
        private const int DisplayArea = Height * Width;
        
        private readonly IDirectoryReader _directoryReader;

        public Analyser(IDirectoryReader directoryReader)
        {
            _directoryReader = directoryReader;
        }

        public async Task RunAsync(string path, int percentOfAreaLimit)
        {
            var images = await _directoryReader.GetFilesListAsync(path).ConfigureAwait(false);
            
            foreach (var img in images)
            {
                if (img.Area / DisplayArea * 100 < percentOfAreaLimit)
                {
                    var newPathName = $"{path}/{percentOfAreaLimit}p";
                    if (!Directory.Exists(newPathName))
                    {
                        Directory.CreateDirectory(newPathName);
                    }
                    
                    File.Move(img.Path, $"{newPathName}/{img.Name}");
                }
            }
        }
    }
}