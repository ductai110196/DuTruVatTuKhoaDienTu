using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Api.Controllers
{
    public class UploadController : Controller
    {
        // GET: Api/Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fileRadom = Guid.NewGuid() + fileName;
                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileRadom);
                if (!Directory.Exists(Server.MapPath("~/Uploads/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
                }
                file.SaveAs(path);
                return fileRadom;
            }
            return "0";
        }
    }
}