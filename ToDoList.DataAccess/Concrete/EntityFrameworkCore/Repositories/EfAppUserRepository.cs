using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository :  IAppUserDAL
    {
        public List<AppUser> GetUsersWithoutAdmins()
        {
            /*
                SELECT
	                *
                FROM
	                AspNetUsers inner join
	                AspNetUserRoles on (AspNetUsers.Id=AspNetUserRoles.UserId) inner join
	                AspNetRoles on (AspNetUserRoles.RoleId=AspNetRoles.Id and AspNetRoles.Name = 'Member')
             */
            using var context = new ToDoContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name != "Admin").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                Surname = I.user.Surname,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName

            }).ToList();

        }

        public List<AppUser> GetUsersWithoutAdmins(out int totalPage, string keyword, int activePage = 1)
        {
            using var context = new ToDoContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name != "Admin").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                Surname = I.user.Surname,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName

            });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if(!string.IsNullOrWhiteSpace(keyword))
            {
                result = result.Where(I => I.Name.ToLower().Contains(keyword.ToLower()) || I.Surname.ToLower().Contains(keyword.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();

        }

        public List<DualHelper> GetMostFinishedWorksAppUsers()
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.AppUser).Where(I => I.Status)
                .GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
                {
                    Name = I.Key,
                    WorksCount = I.Count()
                }).ToList();
        }

        public List<DualHelper> GetMostHaveWorksAppUsers()
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.AppUser).Where(I => !I.Status && I.AppUserId != null)
                .GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
                {
                    Name = I.Key,
                    WorksCount = I.Count()
                }).ToList();
        }
    }
}
