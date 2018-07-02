using System.Threading.Tasks;

namespace Ia.Domain.Interfaces
{
    public interface IFileCompare
    {
        Task<int> Compare(string path, int percentOfAreaLimit, bool byOneDimension);
    }
}