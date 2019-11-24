using System;

namespace Bookstore.Data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}