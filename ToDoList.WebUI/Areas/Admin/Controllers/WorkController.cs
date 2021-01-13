using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.WorkDtos;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public WorkController(IWorkService workService, IUrgencyService urgencyService, IMapper mapper)
        {
            _workService = workService;
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Work;
            return View(_mapper.Map<List<WorkListDto>>(_workService.GetUnfinishedWorksWithUrgency()));
        }

        public IActionResult AddWork()
        {
            TempData["Active"] = TempDataInfo.Work;
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(),"Id", "Description");
            return View(new WorkAddDto());
        }

        [HttpPost]
        public IActionResult AddWork(WorkAddDto model)
        {
            if(ModelState.IsValid)
            {
                _workService.Save(new Work
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId
                });

                return RedirectToAction("Index");
            }
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");
            return View(model);
        }

        public IActionResult UpdateWork(int id)
        {
            TempData["Active"] = TempDataInfo.Work;
            var work = _workService.Get(id);
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description",work.UrgencyId);
            return View(_mapper.Map<WorkUpdateDto>(_workService.Get(id)));
        }

        [HttpPost]
        public IActionResult UpdateWork(WorkUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                _workService.Update(new Work()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId
                });
                return RedirectToAction("Index");
            }
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description", model.UrgencyId);
            return View(model);
        }

        public IActionResult DeleteWork(int id)
        {
            _workService.Delete(new Work { Id = id });
            return Json(null);
        }

        public IActionResult FinishedWorks()
        {
            TempData["Active"] = TempDataInfo.Work;
            return View(_mapper.Map<List<WorkAllListDto>>(_workService.GetAllFinishedWorks()));
        }
    }
}
