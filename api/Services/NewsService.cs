using api.Database;
using api.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class NewsService
    {
        private readonly LufsDbContext _db;

        public NewsService(LufsDbContext db)
        {
            _db = db;
        }

        public async Task<List<News>> ListAll()
        {
            return await _db.News.ToListAsync();
        }
    }
}
