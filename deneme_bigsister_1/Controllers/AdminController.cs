using AutoMapper;
using BigSister.Core.DTOs;
using BigSister.Service.Services;
using BigSister.Core.Models;
using Microsoft.AspNetCore.Mvc;
using BigSister.Core.Services;
using NuGet.Packaging;

namespace deneme_bigsister_1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IService<WorkItem> _workItemService;
        private readonly IService<ConstantValue> _constantValueService;
        private readonly IMapper _mapper;

        public AdminController(IService<WorkItem> workItemService, IMapper mapper, IService<ConstantValue> constantValueService)
        {
            _workItemService = workItemService;
            _mapper = mapper;
            _constantValueService = constantValueService;
        }

        public async Task<IActionResult> Anasayfa()
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

            var workItems = _mapper.Map<IEnumerable<WorkItemDto>>(await _workItemService.GetAllAsync());

            return View(workItems);
        }
        public async Task<IActionResult> WorkItemEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkItemEkle(WorkItemDto workItemDto, IFormFile file)
        {
            ModelState.Remove("ImageUrl");
            if (ModelState.IsValid)
            {

                if (file != null && file.Length > 0)
                {
                    // Dosyayı wwwroot/images klasörüne kaydet
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // ImageUrl özelliğine dosya yolunu kaydet
                    workItemDto.ImageUrl = "/images/" + fileName;
                }

                await _workItemService.AddAsync(_mapper.Map<WorkItem>(workItemDto));
                return RedirectToAction(nameof(Anasayfa));
            }
            return View();
        }
        public async Task<IActionResult> SosyalMedya()
        {
            var constantValues = await _constantValueService.GetAllAsync();
            return View(constantValues);
        }
        [HttpPost]
        public async Task<IActionResult> SosyalMedya(string instagramLink, string facebookLink, string twitterLink, string linkedinLink, string phoneNumber, string locationLink, string emailAddress, string iframeLocationLink)
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

            if (instagram != null && instagramLink!=null)
            {
                instagram.Context = instagramLink;
            }
            if (facebook != null && facebookLink != null)
            {
                facebook.Context = facebookLink;
            }
            if (twitter != null && twitterLink != null)
            {
                twitter.Context = twitterLink;
            }
            if (linkedin != null && linkedinLink != null)
            {
                linkedin.Context = linkedinLink;
            }
            if (phone != null && phoneNumber != null)
            {
                phone.Context = phoneNumber;
            }
            if (location != null && locationLink != null)
            {
                location.Context = locationLink;
            }
            if (email != null && emailAddress != null)
            {
                email.Context = emailAddress;
            }
            if (iframeLocation != null && iframeLocationLink != null)
            {
                iframeLocation.Context = iframeLocationLink;
            }
            List<ConstantValue> values = new List<ConstantValue> { instagram, facebook, twitter, linkedin, phone, location, email, iframeLocation};
            await _constantValueService.UpdateRangeAsync(values);

            return RedirectToAction("Anasayfa");
        }
    }
}
