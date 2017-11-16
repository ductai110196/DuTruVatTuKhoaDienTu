using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
            ViewData["DSNhomLinhVuc"] = new NhomLinhVucModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public string DanhSachDuTruJSON(string maLopHocphan)
        {
            DuTruVatTuModel dt = new DuTruVatTuModel();
            dt.MSGIANGVIEN = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            dt.MSLOPHOCPHAN = int.Parse(maLopHocphan);
            return JsonConvert.SerializeObject(dt.DanhSach(), new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });
        }
    }
}