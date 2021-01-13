using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.BaseControllers;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;
        public HomeController(IWorkService workService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService) : base(userManager)
        {
            _workService = workService;
            _notificationService = notificationService;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Home;
            var user = await GetLoginUser();
            ViewBag.WaitingTaskCount = _workService.GetWaitingTaskCount();
            ViewBag.AllFinishedWorkCount = _workService.GetAllFinishedWorkCount();
            ViewBag.UnReadNotificationCount = _notificationService.GetUnReadNotificationsCount(user.Id);
            ViewBag.AllReportsCount = _reportService.GetAllReportCount();
            return View();
        }
    }
}
