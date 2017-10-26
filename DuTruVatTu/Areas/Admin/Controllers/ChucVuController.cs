using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class ChucVuController : BaseController
    {
        // GET: Admin/ChucVu
        public ActionResult Index()
        {
            ViewData["DSChucVu"] = new ChucVuModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Them(string tenChucVu)
        {
            ChucVuModel cv = new ChucVuModel();
            cv.TENCHUCVU = tenChucVu;
            return cv.Them();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int CapNhat(string msChucVu, string tenChucVu)
        {
            ChucVuModel cv = new ChucVuModel();
            cv.MSCHUCVU = int.Parse(msChucVu);
            cv.TENCHUCVU = tenChucVu;
            return cv.CapNhat();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string msChucVu)
        {
            ChucVuModel cv = new ChucVuModel();
            cv.MSCHUCVU = int.Parse(msChucVu);
            return cv.Xoa();
        }
    }
}