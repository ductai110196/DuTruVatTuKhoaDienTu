using DuTruVatTu.Command;
using DuTruVatTu.Models;
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
    }
}