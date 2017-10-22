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
    public class HocKyNamHocController : BaseController
    {
        // GET: Admin/HocKyNamHoc
        public ActionResult Index()
        {
            ViewData["DSNamHoc"] = new NamHocModel().DanhSach();
            ViewData["DSKhoa"] = new KhoaHocModel().DanhSach();
            return View();
        }

        [HttpPost]
        public string HocKyTheoKhoaHocJSON(string msNamHoc, string msKhoaHoc)
        {
            HocKyModel hk = new HocKyModel();
            hk.MSKHOAHOC = int.Parse(msKhoaHoc);
            hk.MSNAMHOC = int.Parse(msNamHoc);
            return JsonConvert.SerializeObject(
                hk.HocKyTheoKhoaHoc(), new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" }
                );
        }

        [HttpPost]
        public string LayDanhSachHocKyHienTaiTheoKhoaJson(string maKhoa)
        {
            return JsonConvert.SerializeObject(
                new HocKyModel(int.Parse(maKhoa)).HocKyHienTai()
                );
        }
    }
}