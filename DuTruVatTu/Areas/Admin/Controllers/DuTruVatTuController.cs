using DuTruVatTu.Command;
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
            return View();
        }
    }
}