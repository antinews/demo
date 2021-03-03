using Antinew.AspNetCore3._1.Demo.Models;
using Antinew.AspNetCore3._1.Demo.Utility;
using Antinew.AspNetCore3._1.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Antinew.AspNetCore3._1.Demo.Controllers
{

    public class FourthController:Controller
    {
        private readonly ILogger<FourthController> _logger;
        private readonly DbContext _dbContext;
        public FourthController(ILogger<FourthController> logger, DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //using (JDDbContext context = new JDDbContext())
            //{
            //    var user = context.Users.First(x=>x.Id>1);
            //    base.ViewBag.UserName = user.Name;
            //}
            var user = _dbContext.Set<User>().OrderBy(x=>x.Id).Take(5).ToList();
            return View(user);
        }

        [HttpGet]//响应get请求
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        //[CustomAllowAnonymous]
        public ActionResult Login(string name, string password, string verify)
        {
            string verifyCode = base.HttpContext.Session.GetString("CheckCode");
            if (verifyCode != null && verifyCode.Equals(verify, StringComparison.CurrentCultureIgnoreCase))
            {
                if ("admin".SequenceEqual(name) && "123".SequenceEqual(password))
                {
                    CurrentUser currentUser = new CurrentUser()
                    {
                        Id = 123,
                        Name = "小王",
                        Account = "Administrator",
                        Email = "57265177",
                        Password = "123456",
                        LoginTime = DateTime.Now
                    };
                    #region Cookie/Session
                    //base.HttpContext.SetCookies("CurrentUser", Newtonsoft.Json.JsonConvert.SerializeObject(currentUser), 30);
                    //base.HttpContext.Session.SetString("CurrentUser", Newtonsoft.Json.JsonConvert.SerializeObject(currentUser));
                    #endregion
                    //过期时间全局设置

                    #region MyRegion
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,name),
                        new Claim("password",password),//可以写入任意数据
                        new Claim("account","Administrator")
                    };
                    var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(3),
                    }).Wait();//没用await
                    //cookie策略--用户信息---过期时间
                    #endregion

                    return base.Redirect("/Home/Index");
                }
                else
                {
                    base.ViewBag.Msg = "账号密码错误";
                }
            }
            else
            {
                base.ViewBag.Msg = "验证码错误";
            }
            return View();
        }
        public ActionResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session.SetString("CheckCode", code);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }

        [HttpPost]
        //[CustomAllowAnonymous]
        public ActionResult Logout()
        {
            #region Cookie
            base.HttpContext.Response.Cookies.Delete("CurrentUser");
            #endregion Cookie

            #region Session
            CurrentUser sessionUser = base.HttpContext.GetCurrentUserBySession();
            if (sessionUser != null)
            {
                this._logger.LogDebug(string.Format("用户id={0} Name={1}退出系统", sessionUser.Id, sessionUser.Name));
            }
            base.HttpContext.Session.Remove("CurrentUser");
            base.HttpContext.Session.Clear();
            #endregion Session

            #region MyRegion
            //HttpContext.User.Claims//其他信息
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            #endregion
            return RedirectToAction("Index", "Home"); ;
        }
    }
}
