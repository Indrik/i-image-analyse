﻿using Ia.Dao;
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
            var container = DiInstaller.GetServiceContainer();
            var app = container.GetInstance<IAnalyser>();
            
            app.RunAsync(null, 10).Wait();
        }
    }
}