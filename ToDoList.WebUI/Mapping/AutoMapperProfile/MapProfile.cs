using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.DTO.DTOs.AppUserDtos;
using ToDoList.DTO.DTOs.NotificationDtos;
using ToDoList.DTO.DTOs.ReportDtos;
using ToDoList.DTO.DTOs.UrgencyDtos;
using ToDoList.DTO.DTOs.WorkDtos;
using ToDoList.Entities.Concrete;

namespace ToDoList.WebUI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency-UrgencyDtos
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region AppUser-AppUserDtos
            CreateMap<AppUserSignUpDto, AppUser>();
            CreateMap<AppUser, AppUserSignUpDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            #endregion

            #region Notification-NotificationDtos
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Work-WorkDtos
            CreateMap<WorkAddDto, Work>();
            CreateMap<Work, WorkAddDto>();
            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();
            CreateMap<WorkAllListDto, Work>();
            CreateMap<Work, WorkAllListDto>();
            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();
            #endregion

            #region Report-ReportDtos
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
            CreateMap<ReportDocumentDto, Report>();
            CreateMap<Report, ReportDocumentDto>();
            #endregion

        }
    }
}
