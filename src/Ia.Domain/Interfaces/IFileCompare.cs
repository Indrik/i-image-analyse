using System.Threading.Tasks;

namespace Ia.Domain.Interfaces
{
    public interface IFileCompare
    {
        Task Compare(string path, int percentOfAreaLimit, bool byOneDimension);
    }
}