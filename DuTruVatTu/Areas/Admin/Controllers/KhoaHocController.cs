using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class KhoaHocController : BaseController
    {
        // GET: Admin/KhoaHoc
        public ActionResult Index()
        {
            ViewData["DSKhoaHoc"] = new KhoaHocModel().DanhSach();
            return View();
        }

        [HttpPost]
        public int Them(string tenKhoaHoc)
        {
            KhoaHocModel tkh = new KhoaHocModel();
            tkh.TENKHOAHOC = tenKhoaHoc;
            return tkh.Them();
        }

        [HttpPost]
        public int CapNhat(string tenKhoaHoc, string msKhoaHoc)
        {
            KhoaHocModel tkh = new KhoaHocModel();
            tkh.TENKHOAHOC = tenKhoaHoc;
            tkh.MSKHOAHOC =  int.Parse(msKhoaHoc);
            return tkh.CapNhat();
        }

        [HttpPost]
        public int Xoa(string msKhoaHoc)
        {
            KhoaHocModel tkh = new KhoaHocModel();
            tkh.MSKHOAHOC = int.Parse(msKhoaHoc);
            return tkh.Xoa();
        }
    }
}