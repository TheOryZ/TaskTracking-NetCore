using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.ReportDtos;
using ToDoList.DTO.DTOs.WorkDtos;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.BaseControllers;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class TaskAssignmentController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public TaskAssignmentController(IWorkService workService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService, IMapper mapper) : base(userManager)
        {
            _workService = workService;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetLoginUser();
            TempData["Active"] = TempDataInfo.IncomingTasks;
            return View(_mapper.Map<List<WorkAllListDto>>(_workService.GetUnfinishedWorksWithJoins(I => I.AppUserId == user.Id && !I.Status)));
        }

        public IActionResult AddNewReport(int id)
        {
            TempData["Active"] = TempDataInfo.IncomingTasks;
            var work = _workService.GetWithUrgencyId(id);
            ReportAddDto model = new ReportAddDto
            {
                WorkId = id,
                Works = work
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewReport(ReportAddDto model)
        {
            if(ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    WorkId = model.WorkId,
                    Description = model.Description,
                    Subject = model.Subject
                });

                var adminList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await GetLoginUser();
                foreach (var item in adminList)
                {
                    _notificationService.Save(new Notification
                    {
                        Description = $"A user named {activeUser.Name} {activeUser.Surname} has added a new report",
                        AppUserId = item.Id
                    });
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = TempDataInfo.IncomingTasks;
            var report = _reportService.GetReportWithWorkById(id);
            ReportUpdateDto model = new ReportUpdateDto
            {
                Id = report.Id,
                Subject = report.Subject,
                Description = report.Description,
                Works = report.Work,
                WorkId = report.WorkId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                var updatedReport = _reportService.Get(model.Id);

                updatedReport.Subject = model.Subject;
                updatedReport.Description = model.Description;

                _reportService.Update(updatedReport);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> CompleteTask(int workId)
        {
            var updatedWork = _workService.Get(workId);
            updatedWork.Status = true;
            _workService.Update(updatedWork);

            var adminList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await GetLoginUser();
            foreach (var item in adminList)
            {
                _notificationService.Save(new Notification
                {
                    Description = $"The user named {activeUser.Name} {activeUser.Surname} completed the task",
                    AppUserId = item.Id
                });
            }
            return Json(null);
        }
    }
}
