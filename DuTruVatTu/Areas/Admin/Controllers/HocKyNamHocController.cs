using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
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
            return View();
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