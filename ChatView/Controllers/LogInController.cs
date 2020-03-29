using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatView.Models;
using ChatView.Models.DataContext;
using ChatView.Models.Users;
using ChatView.Models.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatView.Controllers
{
    public class LogInController : Controller
    {
        string result = string.Empty;
        public async Task<IActionResult> Index()
        {
            Mcustomer user = new Mcustomer();
            string cookieValue = Request.Cookies["ChatUser"];
            if (cookieValue != null)
            {
                UserModal obj = JsonConvert.DeserializeObject<UserModal>(cookieValue);
                user = await new UserHandler().Authenticate(obj.CustomerCode, obj.Password);
            }
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> LogIn(string email, string Password, bool RememberMe)
        {
            string result = string.Empty;
            try
            {
                Mcustomer user = await new UserHandler().Authenticate(email, Password);
                if (user != null)
                {
                    UserModal model = new UserModal();
                    model.Id=user.Id;
                    model.CustomerCode = user.CustomerCode;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Password = user.Password;
                    model.Role = 1;
                    HttpContext.Session.SetObject(WebUtil.User, model);
                    //new code
                    if (RememberMe == true)
                    {
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(3);
                        string value = JsonConvert.SerializeObject(user);
                        Response.Cookies.Append("ChatUser", value, option);
                    }
                }
                else
                {
                    result = "Invalid Email or Password";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Response.StatusCode = 404;
            }
            return Json(result);
        }
        [HttpPost]
        public IActionResult LogOut()
        {
            try
            {
                HttpContext.Session.Clear();
                result = "success";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);
        }
    }
}