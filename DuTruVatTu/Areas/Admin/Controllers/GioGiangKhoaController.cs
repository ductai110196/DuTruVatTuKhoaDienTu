using DuTruVatTu.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class GioGiangKhoaController : BaseController
    {
        // GET: Admin/GioGiangKhoa
        public ActionResult Index()
        {
            return View();
        }
    }
}