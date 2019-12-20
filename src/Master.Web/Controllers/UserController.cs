using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Reflection;
using Master.Authentication;
using Master.Configuration;
using Master.Controllers;
using Master.EntityFrameworkCore;
using Master.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace Master.Web.Controllers
{
    [AbpMvcAuthorize]
    public class UserController : MasterModuleControllerBase
    {
        public ITypeFinder TypeFinder { get; set; }
        public UserManager UserManager { get; set; }
        public RoleManager RoleManager { get; set; }
        public MasterConfiguration MasterConfiguration { get; set; }

       
       

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Account(string data)
        {
            var roles = await RoleManager.GetAll().ToListAsync();//获取所有角色;
            var user = await UserManager.GetByIdAsync(Convert.ToInt32(data));

            var userRoles = new List<string>();
            userRoles = (await UserManager.GetRolesAsync(user)).Select(o=>o.Name).ToList();

            var statusDefinitions = new List<StatusDefinition>();
            if (MasterConfiguration.EntityStatusDefinitions.ContainsKey(typeof(User)))
            {
                statusDefinitions = MasterConfiguration.EntityStatusDefinitions[typeof(User)];
            }

            ViewData["userroles"] = userRoles;
            ViewData["roles"] = roles;
            ViewData["data"] = data;
            ViewData["statusDefinitions"] = statusDefinitions;
            return View(user);
        }
        [AbpMvcAuthorize("Module.User.Button.Dimission")]
        public async Task<IActionResult> OffJob(string data)
        {
            var ids = data.Split(',').ToList().ConvertAll(o => long.Parse(o));
            var staffNames = await UserManager.GetAll().Where(o => ids.Contains(o.Id)).Select(o => o.Name).ToListAsync();

            ViewData["data"] = data;
            return View(staffNames);
        }
    }
}