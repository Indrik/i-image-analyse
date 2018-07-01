using System.Threading.Tasks;
using Ia.Domain.Models;

namespace Ia.Domain.Interfaces
{
    public interface ICompareCalculator
    {
        Task<bool> IsTooSmallAsync(ImageInfo img, ImageInfo baseImg, int percentOfAreaLimit, bool byOneDimention);
    }
}