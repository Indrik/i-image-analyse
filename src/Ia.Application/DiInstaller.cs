using Ia.Dao;
using Ia.Domain.Interface;
using Ia.Domain.Interfaces;
using LightInject;
using src;

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
            return container;
        }
    }
}