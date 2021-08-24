using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseSecurityHeaders(
            this IApplicationBuilder app)
        {
            app.UseMiddleware<SecurityHeadersMiddleWare>();
        }
    }
    public class SecurityHeadersMiddleWare
    {
        private readonly RequestDelegate next;

        public SecurityHeadersMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {            
            //context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");

            context.Response.Headers.Add("Content-Security-Policy", "default-src: https");

            ////context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

            ////context.Response.Headers.Add("Referrer-Policy", "same-origin");

            context.Response.Headers.Add("Cache-Control", "no-cache no-store");

            /////context.Response.Headers.Add("Strict-Transport-Security", "max-age '31536000'; includeSubdomains; preload");

            context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");

            context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");

            //context.Response.Headers.Add("Set-Cookie", );

            await next(context);
        }
    }
}
