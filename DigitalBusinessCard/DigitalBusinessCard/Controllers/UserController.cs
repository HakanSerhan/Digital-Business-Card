using DigitalBusinessCard.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace DigitalBusinessCard.Controllers
{
   
    public class UserController : Controller
    {
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
            public ActionResult Page405()
            {
                Response.StatusCode = 405;
                Response.TrySkipIisCustomErrors = true;
                return View();
            }
        
        public ActionResult ChangeLanguage(string selectedlanguage, string link)
        {
            if (selectedlanguage != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedlanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedlanguage);
                var cookie = new HttpCookie("Language");
                cookie.Value = selectedlanguage;
                Response.Cookies.Add(cookie);
            }
            return Redirect(link);
        }
        Context c = new Context();
        // GET: User
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Index()
        {
            var degerler = c.Userss.ToList();
            ViewBag.users = degerler;
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult NewUser(Users u)
        {
            c.Userss.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult EditUser(int id)
        {
            var deger = c.Userss.Find(id);
            ViewBag.name = deger.UserName;
            return View("EditUser", deger);
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult UpdateUser(Users u)
        {
            var deger = c.Userss.Find(u.UserID);
            deger.UserName = u.UserName;
            deger.Email = u.Email;
            deger.Password = u.Password;
            deger.UserRole = u.UserRole;

            deger.Verified = u.Verified;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult DeleteUser(int id)
        {
            var deger = c.Userss.Find(id);
            c.Userss.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {

            var giris = c.Userss.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            
            if (giris != null)
            {
                if (giris.Verified==true)
                {

                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Current.Cid = giris.UserID;
                    Current.Cname = giris.UserName;

                    return RedirectToAction("CardProfile", "BusinessCard", new { id = giris.UserID });
                }
                else if (giris.Verified==false)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Current.Cid = giris.UserID;
                    Current.Cname = giris.UserName;

                    return RedirectToAction("VerifyProfile", "User", new { id = giris.UserID });
                }
                return View();
            }
            else
            {
                ViewBag.G = "Kullanıcı Adı veya Şifrenizi Kontrol Ediniz.";
                return View();
            }
        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]
        [HttpGet]
        public ActionResult VerifyProfile(int id)
        {
            var deger = c.Userss.Find(id);
        

            return View("VerifyProfile",deger);


        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        [HttpPost]
        public ActionResult VerifyProfile(Users us)
        {

            var deger = c.Userss.Find(us.UserID);
            deger.Password = us.Password;
            deger.Verified = true;
            c.SaveChanges();
            return RedirectToAction("CardProfile", "BusinessCard", new { id = Current.Cid });


        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Current.Cid = 0;
            Current.Cname = "";
            return RedirectToAction("Index","Home");

        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]

        public ActionResult MyAccount()
        {
            var deger = c.Userss.Find(Current.Cid);
            ViewBag.name = Current.Cname;
            ViewBag.cur = Current.Cid;
            return View(deger);
        }
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]
        public ActionResult UpdateMyProfile(Users u)
        {
            var deger = c.Userss.Find(u.UserID);
            deger.UserName = u.UserName;
            deger.Email = u.Email;
            deger.Password = u.Password;
   
            c.SaveChanges();
            return RedirectToAction("CardProfile", "BusinessCard", new { id = Current.Cid });
        }
    }

}