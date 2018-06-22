using System.Collections.Generic;
using System.Threading.Tasks;
using Ia.Domain.Models;

namespace Ia.Domain.Interfaces
{
    public interface IDirectoryReader
    {
        Task<List<ImageInfo>> GetFilesListAsync(string directory);
    }
}