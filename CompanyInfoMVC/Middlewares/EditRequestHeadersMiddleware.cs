using System;
using Microsoft.Extensions.Configuration;


public class EditRequestHeadersMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration Configuration;
    public EditRequestHeadersMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        Configuration = configuration;
    }


    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(state => {
            var config = Configuration.GetSection("CompanyInfo").Get<Dictionary<string, string>>();
            foreach (var item in config)
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add(item.Key, item.Value);
            }
            return Task.CompletedTask;
        }, context);

        await _next(context);
    }


}


