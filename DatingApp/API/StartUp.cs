using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class StartUp
    {
        private readonly IConfiguration _configuration;
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        public StartUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureHttpContextAccessor(out IHttpContextAccessor httpContextAccessor);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureDbContexts(_configuration);
            services.AddCors();

            this.HttpContextAccessor = httpContextAccessor;
            services.ConfigureCustomServices(HttpContextAccessor, _configuration);
            services.AddControllers(mvcOptions =>
   mvcOptions.EnableEndpointRouting = false)
   .AddNewtonsoftJson();

            services.AddControllers(options =>
                options.OutputFormatters.RemoveType<StringOutputFormatter>()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
