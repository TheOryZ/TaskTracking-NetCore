using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.AppUserDtos;
using ToDoList.DTO.DTOs.ReportDtos;
using ToDoList.DTO.DTOs.WorkDtos;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.BaseControllers;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class TaskAssignmentController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IWorkService _workService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotificationService _notification;
        private readonly IMapper _mapper;
        public TaskAssignmentController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notification, IMapper mapper)
        {
            _appUserService = appUserService;
            _workService = workService;
            _userManager = userManager;
            _fileService = fileService;
            _notification = notification;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Assignment;
            //var model = _appUserService.GetUsersWithoutAdmins();
            return View(_mapper.Map<List<WorkAllListDto>>(_workService.GetUnfinishedWorksWithJoins()));
        }

        public IActionResult AssignUser(int id, string s, int page = 1)
        {
            TempData["Active"] = TempDataInfo.Assignment;
            ViewBag.ActivePage = page;
            ViewBag.Searching = s;
            var users = _mapper.Map<List<AppUserListDto>>(_appUserService.GetUsersWithoutAdmins(out int totalPage, s, page));
            ViewBag.TotalPage = totalPage;
            ViewBag.Users = users;
            return View(_mapper.Map<WorkListDto>(_workService.GetWithUrgencyId(id)));
        }
        [HttpPost]
        public IActionResult AssignUser(AssignUserDto model)
        {
            var updatedWork = _workService.Get(model.WorkId);
            updatedWork.AppUserId = model.AppUserId;
            _workService.Update(updatedWork);
            //Add notification for AppUser
            _notification.Save(new Notification
            {
                AppUserId = model.AppUserId,
                Description = $"You are assigned to name of {updatedWork.Name} task."
            });

            return RedirectToAction("Index");
        }

        public IActionResult AssingUserWithWork(AssignUserDto model)
        {
            TempData["Active"] = TempDataInfo.Assignment;
            AssignUserListDto assignModel = new AssignUserListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.AppUserId)),
                Work = _mapper.Map<WorkListDto>(_workService.GetWithUrgencyId(model.WorkId))
            };
            return View(assignModel);
        }

        public IActionResult ShowDetails(int id)
        {
            TempData["Active"] = TempDataInfo.Assignment;
            return View(_mapper.Map<WorkAllListDto>(_workService.GetWorkWithReports(id)));
        }

        public IActionResult ExportExcel(int id)
        {
            return File(_fileService.ExportExcel(_mapper.Map < List < ReportDocumentDto >>(_workService.GetWorkWithReports(id).Reports)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
        }
        
        public IActionResult ExportPdf(int id)
        {
            var path = _fileService.ExportPdf(_mapper.Map<List<ReportDocumentDto>>(_workService.GetWorkWithReports(id).Reports));
            return File(path,"application/pdf",Guid.NewGuid()+".pdf");
        }

    }
}
