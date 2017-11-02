using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class VatTuPhongController : BaseController
    {
        // GET: Admin/VatTuPhong
        public ActionResult Index()
        {
            PhongModel phong = new PhongModel();
            phong.MSGIANGVIEN = ((TaiKhoanDangNhapModel)Session[Contains.SESSION_KEY_DANGNHAP]).MSGIANGVIEN;
            ViewData["DSPhong"] = new DuTruVatTu.Models.PhongModel().DanhSach();
            return View();
        }

        public string DanhSachVatTu(string maPhong)
        {

        }
    }
}