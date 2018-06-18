using Ia.Domain.Interface;
using LightInject;

namespace Ia.ApplicationV2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.Register<IAnalyser, Analyser>();

            var app = container.GetInstance<IAnalyser>();
            app.RunAsync().Wait();
        }
    }
}