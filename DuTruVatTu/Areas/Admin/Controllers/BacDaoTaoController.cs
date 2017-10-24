﻿using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class BacDaoTaoController : BaseController
    {
        // GET: Admin/BacDaoTao
        public ActionResult Index()
        {
            ViewData["DSBacDaoTao"] = new BacDaoTaoModel().DanhSach();
            return View();
        }

        [HttpPost]
        public int Them(string tenBacDaoTao)
        {
            BacDaoTaoModel bdt = new BacDaoTaoModel();
            bdt.TENBACDAOTAO = tenBacDaoTao;
            return bdt.Them();
        }

        [HttpPost]
        public int CapNhat(string msBacDaoTao, string tenBacDaoTao)
        {
            BacDaoTaoModel bdt = new BacDaoTaoModel();
            bdt.MSBACDAOTAO = int.Parse(msBacDaoTao);
            bdt.TENBACDAOTAO = tenBacDaoTao;
            return bdt.CapNhat();
        }

        [HttpPost]
        public int Xoa(string msBacDaoTao)
        {
            BacDaoTaoModel bdt = new BacDaoTaoModel();
            bdt.MSBACDAOTAO = int.Parse(msBacDaoTao);
            return bdt.Xoa();
        }
    }
}