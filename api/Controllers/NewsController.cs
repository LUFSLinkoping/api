using api.Database.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Route("news")]
    public class NewsController
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
