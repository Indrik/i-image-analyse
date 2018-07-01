using Ia.Business;
using Ia.Dao;
using Ia.Domain.Interface;
using Ia.Domain.Interfaces;
using LightInject;

namespace Ia.Application
{
    internal static class DiInstaller
    {
        public static ServiceContainer GetServiceContainer()
        {
            var container = new ServiceContainer();
            
            container.Register<IAnalyser, Analyser>();
            container.Register<IDirectoryReader, DirectoryReader>();
            container.Register<IFilesReader, FilesReader>();
            container.Register<IFileCompare, FileCompare>();
            container.Register<ICompareCalculator, CompareCalculator>();
            
            return container;
        }
    }
}