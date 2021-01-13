using Microsoft.Extensions.DependencyInjection;
using ToDoList.Business.Concrete;
using ToDoList.Business.CustomLogger;
using ToDoList.Business.Interfaces;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ToDoList.DataAccess.Interfaces;

namespace ToDoList.Business.DiContainer
{
    public static class CustomExtension
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IWorkDAL, EfWorkRepository>();
            services.AddScoped<IUrgencyDAL, EfUrgencyRepository>();
            services.AddScoped<IReportDAL, EfReportRepository>();
            services.AddScoped<IAppUserDAL, EfAppUserRepository>();
            services.AddScoped<INotificationDAL, EfNotificationRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
