using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class DuTruVatTuController : BaseController
    {
        // GET: Admin/DuTru
        public ActionResult Index()
        {
            var magiangvien = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            ViewData["DSLopHocPhan"] = new DuTruVatTuModel().DanhSachLopHocPhanTheoGiangVien(magiangvien);
            return View();
        }

        public string DanhSachDuTruJSON()
        {
            return "";
        }
    }
}