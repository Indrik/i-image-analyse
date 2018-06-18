using Ia.Domain.Interface;
using LightInject;

namespace src
{
    internal static class Program
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