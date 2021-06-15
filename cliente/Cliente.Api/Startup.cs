using cliente.Cliente.Api.Domain.Abstractions;
using cliente.Cliente.Api.Infrastructure;
using Cliente.Api.Infrastructure;
using Cliente.Api.Infrastructure.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SharedKernel.Extensions;
using SharedKernel.Infraestructure.RabbitMQ;

namespace Cliente.Api
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
            services.AddScoped<IUserRepository, UserMongoRepository>();
            services.AddHostedService<ConsumerService>();

            services.AddScoped<IRabbitMQConnection, RabbitMQConnection>();
            services.AddScoped<IEventHandler<WeatherEvent>, WeatherEventHandler>();
            services.Subscribe<IEventHandler<WeatherEvent>, WeatherEventHandler, WeatherEvent>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
