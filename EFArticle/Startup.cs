using EFArticle.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EFArticle
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        private const string DefaultConnectionString = "Default";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            
            services.AddDbContext<EfArticleDbContext>(
                options => options
                    .UseSqlServer(Configuration.GetConnectionString(DefaultConnectionString))
                    .AddInterceptors(new EfCommandInterceptor()));

            services.AddSwaggerGen(
                c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ef Article API", Version = "v1" }));
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EfArticleDbContext dbContext)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            dbContext.Database.EnsureCreated();

            app.UseSwagger();
            app.UseSwaggerUI(
                c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ef Article API"));
        }
    }
}
