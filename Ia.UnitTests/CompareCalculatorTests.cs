using Ia.Business;
using Ia.Domain.Interfaces;
using Ia.Domain.Models;
using NUnit.Framework;
using FluentAssertions;

namespace Ia.UnitTests
{
    [TestFixture]
    public class CompareCalculatorTests
    {
        private readonly ICompareCalculator _compareCalculator = new CompareCalculator();
        
        [Test]
        public void ImageTooSmallByArea()
        {
            var baseImage = new ImageInfo
            {
                Height = 100,
                Width = 100
            };
            var img = new ImageInfo
            {
                Height = 9,
                Width = 9
            };
            var result = _compareCalculator.IsTooSmallAsync(img, baseImage, 10, false).Result;
            result.Should().Be(true);
        }

        [Test]
        public void ImageNormalByArea()
        {
            var baseImage = new ImageInfo
            {
                Height = 100,
                Width = 100
            };
            var img = new ImageInfo
            {
                Height = 10,
                Width = 110
            };
            var result = _compareCalculator.IsTooSmallAsync(img, baseImage, 10, false).Result;
            result.Should().Be(false);
        }

        [Test]
        public void ImageNormalByWidth()
        {
            var baseImage = new ImageInfo
            {
                Height = 100,
                Width = 100
            };
            var img = new ImageInfo
            {
                Height = 9,
                Width = 11
            };
            var result = _compareCalculator.IsTooSmallAsync(img, baseImage, 10, true).Result;
            result.Should().Be(false);
        }

        [Test]
        public void ImageNormalByHeight()
        {
            var baseImage = new ImageInfo
            {
                Height = 100,
                Width = 100
            };
            var img = new ImageInfo
            {
                Height = 11,
                Width = 9
            };
            var result = _compareCalculator.IsTooSmallAsync(img, baseImage, 10, true).Result;
            result.Should().Be(false);
        }

        [Test]
        public void ImageTooSmallByOneDimentionMode()
        {
            var baseImage = new ImageInfo
            {
                Height = 100,
                Width = 100
            };
            var img = new ImageInfo
            {
                Height = 9,
                Width = 9
            };
            var result = _compareCalculator.IsTooSmallAsync(img, baseImage, 10, true).Result;
            result.Should().Be(true);
        }
    }
}