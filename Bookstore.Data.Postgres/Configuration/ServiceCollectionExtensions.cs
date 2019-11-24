using System;
using Bookstore.Data.Postgres.Db;
using Bookstore.Data.Postgres.Repositories;
using Bookstore.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Data.Postgres.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPostgresDb(this IServiceCollection services, Action<BookstoreDatabaseSettings> configuration)
        {
            var dbSettings = new BookstoreDatabaseSettings();
            configuration(dbSettings);
            services.AddSingleton<IBookstoreDatabaseSettings>(dbSettings);
            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseNpgsql(dbSettings.ConnectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork((BookstoreDbContext)sp.GetService(typeof(BookstoreDbContext))));
        }
    }
}