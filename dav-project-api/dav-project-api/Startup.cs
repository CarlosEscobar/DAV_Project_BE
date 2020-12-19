using System.IO;
using dav_project_api.business_logic.Services;
using dav_project_api.data_access.Context;
using dav_project_api.data_access.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace dav_project_api
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "AllowSpecificOrigins";

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
                options.AddPolicy(name: AllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });

            services.AddControllers();

            services.AddDbContext<DavProjectContext>(
                davProjectContext => davProjectContext.UseLazyLoadingProxies()
                                                      .UseSqlServer(Configuration.GetConnectionString("DavProjectDatabase"))
            );
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IGroceryListService, GroceryListService>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IReminderService, ReminderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DavProjectContext davProjectContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            davProjectContext.Database.EnsureCreated();

            app.UseRouting();
            app.UseCors(AllowSpecificOrigins);
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Default")),
                RequestPath = "/default"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
