using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisDemo.Models;
using System.Diagnostics;

namespace RedisDemo.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _distributedCache;
        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;  
        }
        public async Task<ActionResult> SaveRedisCache()
        {
            var dashBoardData = new DashboardData()
            {
                TotalCustomerCount = 1004050,
                TotalRevenue = 120050,
                TotalSpellingCountryName = "Bangladesh",
                TotalSpellingProductName = "Xiomi"
            };

            var tomorrow = DateTime.Now.Date.AddDays(1);
            var totalSeconds = tomorrow.Subtract(DateTime.Now).TotalSeconds;

            var distributedCacheEntryOptions = new DistributedCacheEntryOptions();
            distributedCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(totalSeconds);
            distributedCacheEntryOptions.SlidingExpiration = null;

            var jsonData = JsonConvert.SerializeObject(dashBoardData);
            await _distributedCache.SetStringAsync("DashboardData", jsonData, distributedCacheEntryOptions);
            return View();
        }
    }
}