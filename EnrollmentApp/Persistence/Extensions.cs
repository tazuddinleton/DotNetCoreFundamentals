using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Persistence
{
    public static class Extensions
    {
        public static DbContextOptionsBuilder UseConsoleLoggerFactory(this DbContextOptionsBuilder builder)
        {
            var consoleLoggerFactory = LoggerFactory.Create(config =>
            {
                config.AddFilter((category, level) =>
                {
                    return category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information;
                }).AddConsole();
            });
            return builder.UseLoggerFactory(consoleLoggerFactory);
        }
    }
}
