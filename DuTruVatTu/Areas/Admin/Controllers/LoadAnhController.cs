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
    public class LoadAnhController : Controller
    {
        // GET: Admin/LoadAnh
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string LoadAnhAjax()
        {
            var array = Directory.EnumerateFiles(Server.MapPath("~/Uploads/"))
                          .Select(fn => "/Uploads/" + Path.GetFileName(fn));
            List<HinhAnhModel> listAnh = new List<HinhAnhModel>();
            foreach (var item in array)
            {
                HinhAnhModel temp = new HinhAnhModel();
                temp.URL = item.ToString();
                listAnh.Add(temp);
            }
            return JsonConvert.SerializeObject(listAnh);
        }
    }
}