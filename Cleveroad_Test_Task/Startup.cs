using Cleveroad_Test_Task.Extensions;
using Cleveroad_Test_Task.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Cleveroad_Test_Task
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo() { Title = "Weeather API", Version = "v1" });
            });
            services.Configure<ApiConfig>(Configuration.GetSection(nameof(ApiConfig)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var options = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(options);

            app.UseSwagger(c => 
            {
                c.RouteTemplate = options.JsonRoute;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(options.UiEndpoint, options.Description);
                c.RoutePrefix = string.Empty;
            });
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
