using HaberPortali.Core.Infrastructure;
using HaberPortali.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortali.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region Kullanıcı
            private readonly IUserRepository _userRepository;
            public AccountController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
                //parametreden gelen ile eşitledik

            }
        #endregion 
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userControl = _userRepository.GetMany(x => x.Email == user.Email && x.Sifre == user.Sifre && x.AktifMi == true).SingleOrDefault();
            if (userControl!=null)
            {
                if (userControl.Rol.RolAdi=="Admin")
                {
                    Session["KullaniciEmail"] = userControl.Email;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.mesaj = "Yetkisiz Kullanıcı";
                return View();
            }
            ViewBag.mesaj = "Kullanıcı Bulunamadı";
            return View();
        }
    }
}