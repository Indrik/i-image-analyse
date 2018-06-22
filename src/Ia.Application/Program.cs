using Ia.Dao;
using Ia.Domain.Interface;
using Ia.Domain.Interfaces;
using LightInject;
using src;

namespace Ia.Application
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.Register<IAnalyser, Analyser>();
            container.Register<IDirectoryReader, DirectoryReader>();
            container.Register<IFilesReader, FilesReader>();

            var app = container.GetInstance<IAnalyser>();
            app.RunAsync().Wait();
        }
    }
}