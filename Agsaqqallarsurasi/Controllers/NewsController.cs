using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Helpers;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Agsaqqallarsurasi.Controllers;

public class NewsController : Controller
{
    // GET: NewsController
    private readonly AppDbContext _appDbContext;

    public NewsController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IActionResult> Index()
    {
        List<News> news = await _appDbContext.News

        .OrderByDescending(s => s.Id)
        .Take(8)
        .Include(s => s.NewsImages)
        .ToListAsync();

        return View(news);

    }

    [Route("news/{slug}/{hash}")]
    public async Task<IActionResult> Details(string slug, string hash)
    {
        var newsList = await _appDbContext.News
                                          .Include(n => n.NewsImages)
                                          .ToListAsync();

        var news = newsList.FirstOrDefault(n => UrlHelpers.GenerateHash(n.Id) == hash && UrlHelpers.GenerateSlug(n.Title) == slug);

        if (news == null)
        {
            return NotFound();
        }

        return View(news);
    }




}
