using System.Threading.Tasks;

namespace Ia.Domain.Interface
{
    public interface IAnalyser
    {
        Task RunAsync(string path, int percentOfAreaLimit, bool byOneDimension);
    }
}