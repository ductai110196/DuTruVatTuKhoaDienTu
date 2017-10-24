using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class VatTuController : BaseController
    {
        // GET: Admin/VatTu
        public ActionResult Index()
        {
            ViewData["DSNhomLinhVuc"] = new NhomLinhVucModel().DanhSach();
            return View();
        }


        [HttpPost]
        public string DSVatTuJSON (string msNhomVatTu)
        {
            VatTuModel vt = new VatTuModel();
            vt.MSNHOMVATTU = int.Parse(msNhomVatTu);
            return JsonConvert.SerializeObject(vt.DanhSach());
        }

        [HttpPost]
        public string Upload()
        {
            if(Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                file.SaveAs(path);
                return path;
            }
            return null;
        }
    }
}