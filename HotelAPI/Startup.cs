using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Managers;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HotelAPI
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

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddDbContext<ConsoleApp2.Models.AppContext>(s => s.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=hotel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", b => b.MigrationsAssembly("HotelAPI")));
            services.AddDbContext<ConsoleApp2.Models.AppContext>(s => s.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", b => b.MigrationsAssembly("HotelAPI")));
            services.AddIdentity<AppUser, IdentityRole>()
              .AddEntityFrameworkStores<ConsoleApp2.Models.AppContext>()
              .AddRoleManager<RoleManager<IdentityRole>>()
              .AddSignInManager<SignInManager<AppUser>>()
              .AddUserManager<UserManager<AppUser>>()
              .AddDefaultTokenProviders();

            services.AddTransient<IFlightManager, FlightManager>();
            services.AddTransient<IBookingManager, BookingManager>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>>();
            services.AddTransient<RoleManager<IdentityRole>>();
            services.AddTransient<ConsoleApp2.Models.AppContext>();

            services.AddMvc();

            //services.AddIdentityCore<AppUser>(options => { });

            services.AddScoped<IUserStore<AppUser>, AppUserStore>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
      {
          options.Events.OnRedirectToAccessDenied = ReplaceRedirector(HttpStatusCode.Forbidden, options.Events.OnRedirectToAccessDenied);
          options.Events.OnRedirectToLogin = ReplaceRedirector(HttpStatusCode.Unauthorized, options.Events.OnRedirectToLogin);
      });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();



            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

        }
        static Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(HttpStatusCode statusCode, Func<RedirectContext<CookieAuthenticationOptions>, Task> existingRedirector) =>
    context => {
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            context.Response.StatusCode = (int)statusCode;
            return Task.CompletedTask;
        }
        return existingRedirector(context);
    };
    }
}
