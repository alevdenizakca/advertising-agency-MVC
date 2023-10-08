using AutoMapper;
using BigSister.Core.DTOs;
using BigSister.Service.Services;
using BigSister.Core.Models;
using Microsoft.AspNetCore.Mvc;
using BigSister.Core.Services;

namespace deneme_bigsister_1.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminController : Controller
    {
        private readonly IService<WorkItem> _workItemService;
        private readonly IMapper _mapper;

        public AdminController(IService<WorkItem> workItemService, IMapper mapper)
        {
            _workItemService = workItemService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Anasayfa()
        {
            var workItems =  _mapper.Map<IEnumerable<WorkItemDto>>(await _workItemService.GetAllAsync());

            return View(workItems);
        }
        public async Task<IActionResult> WorkItemEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkItemEkle(WorkItemDto workItemDto)
        {
            if(ModelState.IsValid)
            {
                await _workItemService.AddAsync(_mapper.Map<WorkItem>(workItemDto));
                return RedirectToAction(nameof(Anasayfa));
            }
            return View();
        }
    }
}
