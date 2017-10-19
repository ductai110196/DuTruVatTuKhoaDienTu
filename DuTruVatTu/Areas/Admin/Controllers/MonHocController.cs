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
    public class MonHocController : BaseController
    {
        // GET: Admin/MonHoc
        public ActionResult Index()
        {
            return View();
        }

        // Lấy DS môn học theo bậc đào tạo
        [HttpPost]
        public string MonHocTheoBacDaoTaoJSON(string maBacDaoTao)
        {
            return JsonConvert.SerializeObject(
                new MonHocModel().LayDanhSachMonHoc(maBacDaoTao)
                );
        }
    }
}