
using InfinityTeknoloji.DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace InfinityTeknoloji.UI.Middlewares
{
    public class CreateRolesAndAdminMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IServiceProvider serviceProvider;
        IConfiguration Configuration;


        public CreateRolesAndAdminMiddleware(RequestDelegate next, IServiceProvider service, IConfiguration configuration)
        {
            this.next = next;
            serviceProvider = service;
            Configuration = configuration;

        }

        public async Task Invoke(HttpContext context, RoleManager<IdentityRole> RoleManager, UserManager<User> UserManager)
        {
            //initializing custom roles 

            string[] roleNames = { "Admin", "Teacher", "Student" };
            Task<IdentityResult> roleResult;

            foreach (var roleName in roleNames)
            {
                Task<bool> roleExist = RoleManager.RoleExistsAsync(roleName);
                roleExist.Wait();
                if (!roleExist.Result)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = RoleManager.CreateAsync(new IdentityRole(roleName));
                    roleResult.Wait();
                }
            }
            //Ensure you have these values in your appsettings.json file
            string userPWD = Configuration["AppSettings:UserPassword"];
            Task<User> _user = UserManager.FindByEmailAsync(Configuration["AppSettings:UserEmail"]);
            _user.Wait();
            if (_user.Result == null)
            {
                //Here you could create a super user who will maintain the web app
                var poweruser = new User();
                poweruser.UserName = Configuration["AppSettings:UserEmail"];
                poweruser.Email = Configuration["AppSettings:UserEmail"];
                Task<IdentityResult> createPowerUser = UserManager.CreateAsync(poweruser, userPWD);
                createPowerUser.Wait();
                if (createPowerUser.Result.Succeeded)
                {
                    //here we tie the new user to the role
                    Task<IdentityResult> newUserRole = UserManager.AddToRoleAsync(poweruser, "Admin");
                    newUserRole.Wait();
                }
            }
        }


    }
    public static class CreateRolesAndAdminMiddlewareExtension
    {
        public static IApplicationBuilder UseCreateRolesAndAdminMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CreateRolesAndAdminMiddleware>();
        }
    }
}
