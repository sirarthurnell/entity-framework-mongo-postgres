namespace Bookstore.Data.Repositories
{
    public interface IUnitOfWork
    {
        IBooksRepository BooksRepository { get; }
        void Complete();
    }
}