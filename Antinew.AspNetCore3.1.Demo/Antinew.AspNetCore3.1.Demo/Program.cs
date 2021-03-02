using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Antinew.AspNetCore3._1.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())  // ʹ��autofac�滻IOC����
                .ConfigureLogging((context, ILoggingBuilder) => {   // ʹ��log4net�滻�Դ�����־
                    ILoggingBuilder.AddFilter("System", LogLevel.Warning);
                    ILoggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                    ILoggingBuilder.AddLog4Net();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}