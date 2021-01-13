using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Business.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.WebUI.TagHelpers
{
    [HtmlTargetElement("GetWorkAppUserId")]
    public class WorkAppUserIdTagHelper :TagHelper
    {
        private readonly IWorkService _workService;
        public WorkAppUserIdTagHelper(IWorkService workService)
        {
            _workService = workService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Work> works = _workService.GetByAppUserId(AppUserId);
            int finishedWorksCount = works.Where(I => I.Status).Count();
            int unfinishedWorksCount = works.Where(I => !I.Status).Count();

            string htmlString = $"<strong>Finished Task Count :</strong> {finishedWorksCount}<br><strong> Count of Tasks Worked : </strong> {unfinishedWorksCount}";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
