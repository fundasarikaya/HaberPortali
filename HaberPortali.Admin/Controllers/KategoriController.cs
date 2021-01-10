using HaberPortali.Admin.Class;
using HaberPortali.Core.Infrastructure;
using HaberPortali.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HaberPortali.Admin.CustomFilter;

namespace HaberPortali.Admin.Controllers
{
    public class KategoriController : Controller
    {
        #region Kategori
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        #endregion
        #region Index Kategori Listele
        // GET: Kategori
        public ActionResult Index(int Sayfa=1)
        {
            //return View(_kategoriRepository.GetAll().ToList());
            //sayfalamadan sonra burayı aşağıdaki gibi degiştirdik
            return View(_kategoriRepository.GetAll().OrderByDescending(x=>x.ID).ToPagedList(Sayfa,10));
        }
        #endregion
        #region Kategori Ekle
            [HttpGet]
            public ActionResult Ekle()
            {
                SetKategoriListele();
                return View();
            }
            [HttpPost]
            public JsonResult Ekle(Kategori kategori)
            {
                try
                {
                    _kategoriRepository.Insert(kategori);
                    _kategoriRepository.Save();
                    return Json(new ResultJson { Success = true, Message = "Kategori Ekleme İşleminiz Başarılı" });
                }
                catch (Exception ex)
                {
                    //LOGLAMA YAPABILIRZ
                    return Json(new ResultJson { Success = false, Message = "Kategori Ekleme İşleminiz Gerçekleşemedi" });                
                } 
            }
        #endregion
        #region KategoriSil
            public JsonResult Sil(int ID)
            {
                Kategori dbkategori = _kategoriRepository.GetById(ID);
                if (dbkategori == null)
                {
                    //throw new Exception("Kategori Bulunamadı");
                    return Json(new ResultJson { Success = false, Message = "Kategori Bulunamadı" });
                }
                _kategoriRepository.Delete(ID);
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori Silme İşleminiz Başarılı" });
            }
        #endregion
        #region Set Kategori
        public void SetKategoriListele()
        {
            var KategoriList = _kategoriRepository.GetMany(x => x.ParentID == 0).ToList();
            ViewBag.Kategori = KategoriList;
        }
        #endregion
        #region Kategori Duzenle
        [LoginFilter]
            public ActionResult Duzenle(int id)
            {
                Kategori dbkategori = _kategoriRepository.GetById(id);
                if (dbkategori==null)
                {
                    throw new Exception("Kategori Bulunamadı");
                }
                SetKategoriListele();
                return View(dbkategori);
            } 
            [HttpPost]
        [LoginFilter]
        public JsonResult Duzenle(Kategori kategori)
            {
            //if (ModelState.IsValid)
            //{
                Kategori dbkategori = _kategoriRepository.GetById(kategori.ID);
                dbkategori.AktifMi = kategori.AktifMi;
                dbkategori.KategoriAdi = kategori.KategoriAdi;
                dbkategori.ParentID = kategori.ParentID;
                dbkategori.URL = kategori.URL;
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Duzenleme işlemi başarılı" });
            //}

                //return Json(new ResultJson { Success = false, Message = "Duzenleme işlemi gerçekleştirilemedi" });
            }
        #endregion

    }
}