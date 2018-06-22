using System;
using System.IO;
using Ia.Domain.Interface;
using LightInject;

namespace Ia.Application
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please enter arguments: <analysis path> and <limit of area for image in percent>.");
                return;
            }

            var path = args[0];
            var strLimit = args[1];

            int limit;
            if (!int.TryParse(strLimit, out limit))
            {
                Console.WriteLine("Second argument must be integer.");
                return;
            }
            
            var container = DiInstaller.GetServiceContainer();
            var app = container.GetInstance<IAnalyser>();

            app.RunAsync(path, limit).Wait();
        }
    }
}