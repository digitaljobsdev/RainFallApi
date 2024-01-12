using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RainfallApi.Application.Services;
using RainfallApi.Application.Interfaces;
using RainfallApi.Core.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;


public class Startup
{
    // Existing code...

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IRainfallRepository, RainfallRepository>();
        services.AddScoped<IRainfallService, RainfallService>();
        services.AddScoped<IExternalApiService, ExternalApiService>();

        services.AddControllers();

        // Register the Swagger generator
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Rainfall API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Sorted",
                    Url = new System.Uri("https://www.sorted.com")
                },
                Description = "An API which provides rainfall reading data"
            });

            // Include the XML comments in Swagger for better documentation
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Add other endpoints as needed
            });

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rainfall API V1");
            c.RoutePrefix = "swagger"; // Serve the Swagger UI at the root
            c.DocExpansion(DocExpansion.None);
        });

        // Existing code...
    }
}
