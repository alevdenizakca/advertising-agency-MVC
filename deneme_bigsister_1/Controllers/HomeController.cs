using BigSister.Core.Models;
using BigSister.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace deneme_bigsister_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<ConstantValue> _constantValueService;
        private readonly IService<WorkItem> _workItemService;



        public HomeController(ILogger<HomeController> logger, IService<ConstantValue> constantValueService, IService<WorkItem> workItemService)
        {
            _logger = logger;
            _constantValueService = constantValueService;
            _workItemService = workItemService;
        }

        public async Task<IActionResult> anasayfa()
        {
            var constantValues = await _constantValueService.GetAllAsync();
            var instagram = constantValues.FirstOrDefault(x => x.Section == "instagram");
            var facebook = constantValues.FirstOrDefault(x => x.Section == "facebook");
            var twitter = constantValues.FirstOrDefault(x => x.Section == "twitter");
            var linkedin = constantValues.FirstOrDefault(x => x.Section == "linkedin");
            var phone = constantValues.FirstOrDefault(x => x.Section == "phone");
            var location = constantValues.FirstOrDefault(x => x.Section == "location");
            var email = constantValues.FirstOrDefault(x => x.Section == "email");
            var iframeLocation = constantValues.FirstOrDefault(x => x.Section == "iframeLocation");
            ViewBag.Email = email.Context;
            ViewBag.Location = location.Context;
            ViewBag.Instagram = instagram.Context;
            ViewBag.Facebook = facebook.Context;
            ViewBag.Twitter = twitter.Context;
            ViewBag.Linkedin = linkedin.Context;
            ViewBag.Phone = phone.Context;
            ViewBag.IframeLocation = iframeLocation.Context;
            var workItems = (await _workItemService.GetAllAsync()).Take(6).ToList();
            return View(workItems);
        }

        public IActionResult hakkimizda()
        {
            return View();
        }
        public async Task<IActionResult> islerimiz(int page=1)
        {
            var values = (await _workItemService.GetAllAsync()).ToPagedList(page,6);
            return View(values);
        }
        public async Task<IActionResult> iletisim() 
        {
            var constantValues = (await _constantValueService.GetAllAsync());
            return View(constantValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}