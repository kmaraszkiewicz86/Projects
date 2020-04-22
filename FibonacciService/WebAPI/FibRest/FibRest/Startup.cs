using Core.AppSettings;
using Core.Core;
using Core.Helpers;
using Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FibRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("localhost", builder =>
                {
                    builder
                       .WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
                });
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionBuilderHelper.GetDefaultConnectionString()));

            var rabbitMq = ConnectionBuilderHelper.BuildDefault().GetSection(nameof(RabbitMq)).Get<RabbitMq>();

            services.AddSingleton<IRabbitMqService>(options =>
            {
                var rabbitMqService = new RabbitMqService(rabbitMq);
                rabbitMqService.Start();

                return rabbitMqService;
            });
            services.AddScoped<IFibCalcService, FibCalcService>();
            services.AddScoped<IFibDbService, FibDbService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseRouting();

            app.UseCors("localhost");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
