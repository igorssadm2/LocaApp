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

            services.AddScoped<IAuthenticantionService,AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<INotificador, Notificador>();
            
            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
