using api.Database.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    public class NewsController : BaseController
    {
        private readonly ILogger<NewsController> _logger;

        private readonly NewsService _newsService;
        public NewsController(ILogger<NewsController> logger, NewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IEnumerable<News>> Get()
        {
            return await _newsService.ListAll();
        }
    }
}
