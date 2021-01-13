using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoList.Business.Interfaces;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;
        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Graphic;
            return View();
        }

        public IActionResult MostFinishedWorksAppUsers()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostFinishedWorksAppUsers());
            return Json(jsonString);
        }
        public IActionResult MostHaveWorksAppUsers()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetMostHaveWorksAppUsers());
            return Json(jsonString);
        }
    }
}
