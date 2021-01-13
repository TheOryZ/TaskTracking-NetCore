using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.UrgencyDtos;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Urgency;
            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetAll()));
        }

        public IActionResult AddUrgency()
        {
            TempData["Active"] = TempDataInfo.Urgency;
            return View(new UrgencyAddDto());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if(ModelState.IsValid)
            {
                _urgencyService.Save(new Urgency()
                {
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = TempDataInfo.Urgency;
            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.Get(id)));
        }
        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency()
                {
                    Id = model.Id,
                    Description = model.Description
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
