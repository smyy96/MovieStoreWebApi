using FluentValidation;
using MovieStoreWebApi.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace MovieStoreWebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {

            var watch = Stopwatch.StartNew();// neyin ne kadar sürede çalıştığını bilen bir timer

            try
            {

                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path; // execute ettiğimiz zaman hangi http request metodunun çalıştığını ve hangi path kullanıldığını verir
                _loggerService.Write(message);
                await _next(context); // bir sonraki middleware çağrıldı.

                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms"; // bu servis içerisinde ne kadar zaman harcandığı ve durum kodlarının bilgisi veriliyor
                _loggerService.Write(message);
            }
            catch (Exception e)
            {
                watch.Stop();
                await HandleException(context, e, watch);
                throw;
            }
        }


        private Task HandleException(HttpContext context, Exception e, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + "Error Message" + e.Message + " in " + watch.Elapsed.TotalMilliseconds + "ms";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }

        /*   Örnek çıktılar
            [Request] HTTP GET - /Movies
            [Response] HTTP GET - /Movies responded 200 in 41,2763ms
            [Request] HTTP PUT - /Movies/1
            [Response] HTTP PUT - /Movies/1 responded 400 in 88,7796ms

        */
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}



