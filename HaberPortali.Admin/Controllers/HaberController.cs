using HaberPortali.Admin.CustomFilter;
using HaberPortali.Core.Infrastructure;
using HaberPortali.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortali.Admin.Controllers
{
    public class HaberController : Controller
    {
        #region Veritabanı
        private readonly IHaberRepository _haberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IKategoriRepository _kategoriRepository;

        #endregion
        public HaberController(IHaberRepository haberRepository,IUserRepository userRepository,IKategoriRepository kategoriRepository)
        {
            _haberRepository = haberRepository;
            _userRepository = userRepository;
            _kategoriRepository = kategoriRepository;
        }
        // GET: Haber
        public ActionResult Index()
        {
            return View();
        }
        #region Ekle
            [HttpGet]
            [LoginFilter]
            public ActionResult Ekle()
            {
                SetKategoriListele();
                return View();
            }
            [HttpPost]
            [LoginFilter]
            public ActionResult Ekle(Haber haber)
            {
                    var SessionControl = HttpContext.Session["KullaniciEmail"];
            //if (ModelState.IsValid)
           // {
                User user = _userRepository.GetById(Convert.ToInt32(SessionControl));
                    haber.UserID = user.ID;
               // haber.KategoriID = Kategori;
                    _haberRepository.Insert(haber);
                    _haberRepository.Save();
        //}
                return View();
            }
        #endregion
        #region Set Kategori Listesi
        public void SetKategoriListele(object kategori = null)
        {
            var KategoriListe = _kategoriRepository.GetMany(x => x.ParentID == 0).ToList();

            ViewBag.Kategori = KategoriListe;
        }
        #endregion
    }
}
//10.video hatayı hallet
