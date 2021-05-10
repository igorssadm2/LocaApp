using LocaApp.FrameWork.Interfaces;
using LocaApp.FrameWork.Notificacoes;
using LocaApp.FrameWork.Usuario;
using LocaApp.Identidade.API.Service;
using LocaApp.Identidade.API.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace LocaApp.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(origin => true)
                        .AllowCredentials();
                });
            });
                
            services.AddScoped<IAuthenticantionService,AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
