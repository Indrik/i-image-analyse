using System.Collections.Generic;
using System.Threading.Tasks;
using Ia.Domain.Models;

namespace Ia.Domain.Interfaces
{
    public interface IFilesReader
    {
        Task<List<ImageInfo>> GetDirectoryFilesAsync(string[] filesList);
    }
}