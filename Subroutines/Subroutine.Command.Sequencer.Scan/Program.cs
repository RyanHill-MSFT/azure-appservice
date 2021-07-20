﻿using System;
using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Subroutine.Command.Sequencer.Scan
{
    class Program
    {
        static async void Main()
        {
            var host = new HostBuilder()
                .UseEnvironment("Development")
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices().AddTimers();
                })
                .ConfigureLogging((context, b) =>
                {
                    b.AddConsole();
                })
                .UseConsoleLifetime()
                .Build();

            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
