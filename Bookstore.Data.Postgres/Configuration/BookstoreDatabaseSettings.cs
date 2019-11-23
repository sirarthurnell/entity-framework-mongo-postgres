namespace Bookstore.Data.Postgres.Configuration
{
    public interface IBookstoreDatabaseSettings
    {
        string ConnectionString { get; set; }
    }

    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}