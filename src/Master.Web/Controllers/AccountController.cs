using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Controllers;
using Master.MultiTenancy;
using Master.Web.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Master.Web.Controllers
{
    public class AccountController : MasterControllerBase
    {
        private readonly TenantManager _tenantManager;
        public AccountController(
            TenantManager tenantManager
            )
        {
            _tenantManager = tenantManager;
        }
        public async Task<ActionResult> Login()
        {
            
            return View();
        }
        public ActionResult Logout()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("Login");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}