using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Log.API.IoC;

public static class StartLogApi
{
    public static IServiceCollection ConfigLogApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", CreateApiInfo());
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            opt.IncludeXmlComments(xmlPath);
            xmlFile = $"Log.Domain.xml";
            xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            opt.IncludeXmlComments(xmlPath);
            xmlFile = $"Log.Toolkit.xml";
            xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            opt.IncludeXmlComments(xmlPath);

        });

        return services;
    }

    public static void UseLogApi(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Log.API v1"));
    }

    private static OpenApiInfo CreateApiInfo()
    {
        return new OpenApiInfo
        {
            Title = "Log API",
            Version = "v1",
            Description = "Essa é uma Api de fins didáticos, criada testar o ILogger com Grafana. ",
            Contact = new OpenApiContact
            {
                Name = "Caique SS",
                Email = "caique.soares@pierserv.com.br",
                Url = new Uri("https://github.com/caiquefirefox")
            },
            License = new OpenApiLicense
            {
                Name = "GPL-3.0",
                Url = new Uri("https://opensource.org/licenses/GPL-3.0")
            },
            TermsOfService = new Uri("https://opensource.org/licenses/GPL-3.0")
        };
    }
}
