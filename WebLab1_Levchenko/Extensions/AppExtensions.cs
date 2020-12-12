using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using WebLab1_Levchenko.Middleware;

namespace WebLab1_Levchenko.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
            => app.UseMiddleware<LogMiddleware>();
    }
}
