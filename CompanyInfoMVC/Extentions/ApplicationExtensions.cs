using System;
namespace CompanyInfoMVC.Extentions
{
    public static class ApplicationExtentions
    {
        public static IApplicationBuilder UseContent(this IApplicationBuilder app)
        {
            return app.UseMiddleware<EditRequestHeadersMiddleware>();
        }
    }
}

