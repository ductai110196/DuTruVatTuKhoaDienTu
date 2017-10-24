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
    public class NhomVatTuController : BaseController
    {
        // GET: Admin/NhomVatTu
        public ActionResult Index()
        {
            ViewData["DSNhomLinhVuc"] = new NhomLinhVucModel().DanhSach();
            return View();
        }

        [HttpPost]
        public string DSNhomVatTuJSON(string msNhomLinhVuc)
        {
            NhomVatTuModel nvt = new NhomVatTuModel();
            nvt.MSNHOMLINHVUC = int.Parse(msNhomLinhVuc);
            return JsonConvert.SerializeObject(nvt.DanhSach());
        }

    }
}