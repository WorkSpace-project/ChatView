using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatView.Models.DataContext;
using ChatView.Models.Users;
using ChatView.Models.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ChatView.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            UserModal user = HttpContext.Session.GetObject<UserModal>(WebUtil.User);
            if (user == null || user.Role != WebUtil.Admin)
            {
                return RedirectToAction("Index", "LogIn");
            }
            else
            {
                return View(user);
            }
        }
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                UserModal user = HttpContext.Session.GetObject<UserModal>(WebUtil.User);
                if (user == null || user.Role != WebUtil.Admin)
                {
                    return RedirectToAction("Index", "LogIn");
                }
                else
                {
                    using (Context db = new Context())
                    {
                        List<Mcustomer> customers = db.Mcustomers.ToList();
                        return Json(customers);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
    }
}