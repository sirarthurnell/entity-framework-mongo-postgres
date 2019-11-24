using System;
using Bookstore.Data.MongoDb.Repositories;
using Bookstore.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Data.MongoDb.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, Action<BookstoreDatabaseSettings> configuration)
        {
            var dbSettings = new BookstoreDatabaseSettings();
            configuration(dbSettings);
            services.AddSingleton<IBookstoreDatabaseSettings>(dbSettings);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}