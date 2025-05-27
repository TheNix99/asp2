using Microsoft.AspNetCore.Http.Extensions;
using MVC.Data;

namespace MVC.Models.Middleware;

public class RequestLogMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ApplicationDbContext _dbContext;    

    public RequestLogMiddleWare(RequestDelegate next, ApplicationDbContext dbContext)
    {
        _next = next;
        //_dbContext = dbContext;
       
    }
    public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext dbContext)
    {
        var ip = httpContext.Connection.RemoteIpAddress.ToString();
        var url = httpContext.Request.GetDisplayUrl();

        var log = new RequestLog
        {
            RequestDate = DateTime.Now,
            Url = url,
            IpAddress = ip
        };

        dbContext.RequestLogs.Add(log);
        dbContext.SaveChanges();

        // Call the next delegate/middleware in the pipeline
        await _next(httpContext);
    }
}

public static class MyCustomMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLogMiddleWare>();
    }
}