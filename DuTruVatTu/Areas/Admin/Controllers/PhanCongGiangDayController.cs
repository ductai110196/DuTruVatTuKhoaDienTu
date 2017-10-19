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
    public class PhanCongGiangDayController : BaseController
    {
        // GET: Admin/PhanCongGiangDay
        public ActionResult Index()
        {
            ViewData["DSBacDaoTao"] = new BacDaoTaoModel().DanhSach();
            ViewData["DSKhoaHoc"] = new KhoaHocModel().DanhSach();
            return View();
        }

        [HttpPost]
        public string DanhSachPhanCongGiangDay(string maHocKy, string maHocPhan)
        {
            return JsonConvert.SerializeObject(
               new PhanCongGiangDayModel().DanhSach(maHocKy, maHocPhan)
               );
        }

        [HttpPost]
        public ActionResult CapNhat(ICollection<string> MSPHANCONGGIANGDAY, ICollection<string> MSLOPHOCPHAN,
            ICollection<string> MSGIANGVIEN)
        {
            var listPhanCong = MSPHANCONGGIANGDAY.ToArray();
            var listLopHocPhan = MSLOPHOCPHAN.ToArray();
            var listGiangVien = MSGIANGVIEN.ToArray();
            PhanCongGiangDayModel pc = new PhanCongGiangDayModel();
            for (int i = 0; i < listPhanCong.Length; i++)
            {
                pc.MSPHANCONGGIANGDAY = int.Parse(listPhanCong[i]);
                pc.MSLOPHOCPHAN = int.Parse(listLopHocPhan[i]);
                pc.MSGIANGVIEN = int.Parse(listGiangVien[i]);
                pc.CapNhat();
            }
            return RedirectToAction("Index", "PhanCongGiangDay", new { area = "Admin" });
        }
    }
}