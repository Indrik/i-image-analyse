using Ia.Domain.Interface;
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

            var app = container.GetInstance<IAnalyser>();
            app.Run();
        }
    }
}