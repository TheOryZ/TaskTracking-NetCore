using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.AppUserDtos;
using ToDoList.Entities.Concrete;

namespace ToDoList.WebUI.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(identityUser);
            
            
            var notifications = _notificationService.GetUnReadNotifications(model.Id).Count;
            ViewBag.NotificationCount = notifications;
            var roles = _userManager.GetRolesAsync(identityUser).Result;
            if(roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
        }
    }
}
