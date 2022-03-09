
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Middlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;
        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var _logger = loggerFactory.CreateLogger<ErrorHandling>();
                _logger.LogError(ex.ToString());
                context.Response.Redirect("/Home/Error");
            }
        }
    }
}
