using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuTruVatTu.Models
{
    public class QuyenHanModel
    {
        public bool BACDAOTAO { get; set; }
        public bool CHUCVU { get; set; }
        public bool DUTRUVATTU { get; set; }
        public bool GIANGVIEN { get; set; }
        public bool HOCKYNAMHOC { get; set; }
        public bool KHOAHOC { get; set; }
        public bool LOPHOCPHAN { get; set; }
        public bool MONHOC { get; set; }
        public bool NHOMLINHVUC { get; set; }
        public bool NHOMVATTU { get; set; }
        public bool PHANCONGGIANGDAY { get; set; }
        public bool PHONG { get; set; }
        public bool QUANLYTAIKHOAN { get; set; }
        public bool DANGNHAP { get; set; }
        public bool VATTU { get; set; }
        public bool VATTUPHONG { get; set; }
        public bool THONGKEVATTUPHONG { get; set; }
        public bool THONGKEDUTRUVATTU { get; set; }

        public QuyenHanModel()
        {
        }

        public string GetJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void SetJSON(string json)
        {
            var data = JsonConvert.DeserializeObject<QuyenHanModel>(json);
            this.BACDAOTAO = data.BACDAOTAO;
            this.CHUCVU = data.CHUCVU;
            this.DUTRUVATTU = data.DUTRUVATTU;
            this.GIANGVIEN = data.GIANGVIEN;
            this.HOCKYNAMHOC = data.HOCKYNAMHOC;
            this.KHOAHOC = data.KHOAHOC;
            this.LOPHOCPHAN = data.LOPHOCPHAN;
            this.MONHOC = data.MONHOC;
            this.NHOMLINHVUC = data.NHOMLINHVUC;
            this.NHOMVATTU = data.NHOMVATTU;
            this.PHANCONGGIANGDAY = data.PHANCONGGIANGDAY;
            this.PHONG = data.PHONG;
            this.QUANLYTAIKHOAN = data.QUANLYTAIKHOAN;
            this.DANGNHAP = data.DANGNHAP;
            this.VATTU = data.VATTU;
            this.VATTUPHONG = data.VATTUPHONG;
            this.THONGKEDUTRUVATTU = data.THONGKEDUTRUVATTU;
            this.THONGKEVATTUPHONG = data.THONGKEVATTUPHONG;
        }
    }
}