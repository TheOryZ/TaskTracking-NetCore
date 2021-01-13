using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Business.Interfaces;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.BaseControllers;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IWorkService workService, INotificationService notificationService) : base(userManager)
        {
            _reportService = reportService;
            _workService = workService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Home;
            var user = await GetLoginUser();
            ViewBag.ReportCount = _reportService.GetReportCount(user.Id);
            ViewBag.FinishedWorkCount = _workService.GetFinishedWorkCount(user.Id);
            ViewBag.ActiveWorkCount = _workService.GetActiveWorkCount(user.Id);
            ViewBag.UnReadNotificationsCount = _notificationService.GetUnReadNotificationsCount(user.Id);
            return View();
        }
    }
}
