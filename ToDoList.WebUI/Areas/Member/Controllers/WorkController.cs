using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.Interfaces;
using ToDoList.DTO.DTOs.WorkDtos;
using ToDoList.Entities.Concrete;
using ToDoList.WebUI.BaseControllers;
using ToDoList.WebUI.StringInfo;

namespace ToDoList.WebUI.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class WorkController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly IMapper _mapper;
        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _workService = workService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = TempDataInfo.CompletedTasks;
            var user = await GetLoginUser();
            var works = _mapper.Map<List<WorkAllListDto>>(_workService.GetUnfinishedWorksWithPaging(out int totalPage, user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            return View(works);
        }
    }
}
