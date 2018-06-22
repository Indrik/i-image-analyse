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
        private readonly IFilesReader _filesReader;

        public DirectoryReader(IFilesReader filesReader)
        {
            _filesReader = filesReader;
        }

        public async Task<List<ImageInfo>> GetFilesListAsync(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException(directory);
            }
            
            var filesList = Directory.GetFiles(directory);
            return await _filesReader.GetDirectoryFilesAsync(directory, filesList).ConfigureAwait(false);
        }
    }
}