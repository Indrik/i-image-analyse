using System.Threading.Tasks;
using Ia.Domain.Interfaces;
using Ia.Domain.Models;

namespace Ia.Business
{
    public class CompareCalculator : ICompareCalculator
    {
        public async Task<bool> IsTooSmallAsync(ImageInfo img, ImageInfo baseImg, int percentOfAreaLimit, bool byOneDimention)
        {
            if (!byOneDimention)
            {
                decimal area = (decimal)img.Area / baseImg.Area * 100;
                return area < percentOfAreaLimit;
            }

            var heightDiff = (decimal)img.Height / baseImg.Height * 100;
            var widthDiff = (decimal)img.Width / baseImg.Width * 100;

            return !(heightDiff > percentOfAreaLimit) && !(widthDiff > percentOfAreaLimit);
        }
    }
}