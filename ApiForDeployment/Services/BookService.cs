using ApiForDeployment.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace ApiForDeployment.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;
        private readonly MongoDBConfig _config;
        public BookService(IOptions<MongoDBConfig> options)
        {
            _config = options.Value;
            var client = new MongoClient(_config.ConnectionString);
            var database = client.GetDatabase(_config.DatabaseName);
            _books = database.GetCollection<Book>(_config.BookCollectionName);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _books.Find(c => true).ToListAsync();
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }
    }
}
