using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.NotificationDtos;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.BaseControllers;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Notifications;
            var user = await GetLoginUser();
            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetUnReadNotifications(user.Id)));
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var notification = _notificationService.Get(id);
            notification.Status = true;
            _notificationService.Update(notification);
            return RedirectToAction("Index");
        }
    }
}
