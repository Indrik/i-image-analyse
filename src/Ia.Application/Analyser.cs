using System;
using System.Threading.Tasks;
using Ia.Domain.Interface;
using Ia.Domain.Interfaces;

namespace Ia.Application
{
    public class Analyser : IAnalyser
    {
        private readonly IFileCompare _fileCompare;

        public Analyser(IFileCompare fileCompare)
        {
            _fileCompare = fileCompare;
        }

        public async Task RunAsync(string path, int percentOfAreaLimit, bool byOneDimension)
        {
            var moved = await _fileCompare.Compare(path, percentOfAreaLimit, byOneDimension).ConfigureAwait(false);
            
            Console.WriteLine("Complete...");
            Console.WriteLine($"Moved: {moved}");
        }
    }
}