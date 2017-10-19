﻿using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class LopHocPhanController : BaseController
    {
        // GET: Admin/LopHocPhan
        public ActionResult Index()
        {
            ViewData["DSBacDaoTao"] = new BacDaoTaoModel().DanhSach();
            ViewData["DSKhoaHoc"] = new KhoaHocModel().DanhSach();
            HocKyModel m = new HocKyModel();
            return View();
        }

        [HttpPost]
        public string LopHocPhanJSON(string hocKy, string maHocPhan)
        {
            return JsonConvert.SerializeObject(
                new LopHocPhanModel(int.Parse(maHocPhan), int.Parse(hocKy)).DanhSach()
                );
        }

        [HttpPost]
        public int ThemJSON(string hocKy, string maHocPhan, string maLopHocphan, 
            string tenLopHocPhan, string siSo, string loaiLopHocPhan)
        {
            int st =  new LopHocPhanModel(maLopHocphan, tenLopHocPhan, int.Parse(siSo),
                    int.Parse(loaiLopHocPhan), int.Parse(maHocPhan), int.Parse(hocKy)).Them();
            if (st > 0)
                return new PhanCongGiangDayModel().Them();
            return 0;
        }

        [HttpPost]
        public int CapNhatJSON(string msLopHocPhan, string hocKy, string maHocPhan, string maLopHocPhan,
            string tenLopHocPhan, string siSo, string loaiLopHocPhan)
        {
            return new LopHocPhanModel(int.Parse(msLopHocPhan), maLopHocPhan, tenLopHocPhan, int.Parse(siSo),
                    int.Parse(loaiLopHocPhan), int.Parse(maHocPhan), int.Parse(hocKy)).CapNhat();
        }

        [HttpPost]
        public int XoaJSON(string msLopHocPhan)
        {
            return new LopHocPhanModel(int.Parse(msLopHocPhan)).Xoa();
        }
    }
}