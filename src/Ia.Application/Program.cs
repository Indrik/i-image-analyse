using System;
using Ia.Domain.Interface;
using LightInject;

namespace Ia.Application
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter arguments: <analysis path> and <limit of area for image in percent>.");
                return;
            }
            
            var container = DiInstaller.GetServiceContainer();
            var app = container.GetInstance<IAnalyser>();
            
            app.RunAsync(null, 10).Wait();
        }
    }
}