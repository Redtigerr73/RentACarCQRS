using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.MVC.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            
                using var buffer = new MemoryStream();
                var response = httpContext.Response;
                var stream = response.Body;
                response.Body = buffer;
                await _next(httpContext);
                var userName = httpContext.User.Claims.Any() == false ? "" : httpContext.User.Claims.ElementAt(0).Value;
                var infoMsg = userName != "" ? "User currently logged: " + userName : "Nobody is logged in";
                Debug.WriteLine(infoMsg);
                buffer.Position = 0;
                await buffer.CopyToAsync(stream);
            
        }


    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
