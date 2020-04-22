using ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyRegistrar
{
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static void ConfigureGloabalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
