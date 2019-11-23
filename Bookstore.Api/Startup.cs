using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Bookstore.Data.Postgres.Configuration;
using Bookstore.Data.Postgres.Repositories;
using Bookstore.Data.Repositories;
using Bookstore.Data.Postgres.Db;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApi
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
            var dbSettings = new BookstoreDatabaseSettings();
            Configuration.GetSection(nameof(BookstoreDatabaseSettings) + ":Postgres").Bind(dbSettings);
            services.AddSingleton<IBookstoreDatabaseSettings>(dbSettings);
            services.AddDbContext<BookstoreDbContext>(options => {
                options.UseNpgsql(dbSettings.ConnectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork((BookstoreDbContext)sp.GetService(typeof(BookstoreDbContext))));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
