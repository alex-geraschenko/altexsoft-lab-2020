using System;
using HomeTask4.Core.Entities;
using HomeTask4.Infrastructure.Extensions;
using HomeTask4.SharedKernel.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/// <summary>
/// A skeleton for the Home Task 4 in AltexSoft Lab 2020
/// For more details how to organize configuration, logging and dependency injections in console app
/// watch https://www.youtube.com/watch?v=GAOCe-2nXqc
///
/// For more information about General Host
/// read https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.1
///
/// For more information about Logging
/// read https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1
///
/// For more information about Dependency Injection
/// read https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
/// </summary>
namespace HomeTask4.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Hello World!");

            logger.LogDebug("Trying to get repository...");
            var unitOfWork = host.Services.GetRequiredService<IUnitOfWork>();

            try
            {
                logger.LogDebug("Trying to get temp entity...");
                var entity = unitOfWork.Repository.GetByIdAsync<TempEntity>(1);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred durign getting temp entity");
            }

            logger.LogInformation("Good bye!");

            Console.ReadLine();
        }

        /// <summary>
        /// This method should be separate to support EF command-line tools in design time
        /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
        /// </summary>
        /// <param name="args"></param>
        /// <returns><see cref="IHostBuilder" /> hostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddInfrastructure(context.Configuration.GetConnectionString("Default"));
               })
               .ConfigureLogging(config =>
               {
                   config.ClearProviders();
                   config.AddConsole();
               });
    }
}
