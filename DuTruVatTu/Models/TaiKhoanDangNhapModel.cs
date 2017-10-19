using DuTruVatTu.Database;
using DuTruVatTu.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuTruVatTu.Models
{
    public class TaiKhoanDangNhapModel : iTaiKhoanDangNhap, iGiangVien
    {
        public int MSGIANGVIEN {get; set; }
        public string MAGIANGVIEN { get; set; }
        public string TENGIANGVIEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public int MATAIKHOAN { get; set; }
        public string TENDANGNHAP { get; set; }
        public string MATKHAU { get; set; }
        public string PHANQUYEN { get; set; }
        public string ANHDAIDIEN { get; set; }
        public string EMAIL { get; set; }

        public TaiKhoanDangNhapModel()
        {
        }

        public TaiKhoanDangNhapModel(string tENDANGNHAP, string mATKHAU)
        {
            TENDANGNHAP = tENDANGNHAP;
            MATKHAU = mATKHAU;
        }

        public TaiKhoanDangNhapModel(int mATAIKHOAN)
        {
            MATAIKHOAN = mATAIKHOAN;
        }

        public TaiKhoanDangNhapModel(int mATAIKHOAN, string tENDANGNHAP, string mATKHAU, string pHANQUYEN, 
            string aNHDAIDIEN, string eMAIL)
        {
            TENDANGNHAP = tENDANGNHAP;
            MATKHAU = mATKHAU;
            PHANQUYEN = pHANQUYEN;
            ANHDAIDIEN = aNHDAIDIEN;
            EMAIL = eMAIL;
            MATAIKHOAN = mATAIKHOAN;
        }

        public List<TaiKhoanDangNhapModel> DangNhap()
        {
            List<TaiKhoanDangNhapModel> list = new List<TaiKhoanDangNhapModel>();
            Object[] par = {
                new SqlParameter("@mATAIKHOAN", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENDANGNHAP", TENDANGNHAP),
                new SqlParameter("@mATKHAU", MATKHAU),
                new SqlParameter("@pHANQUYEN", DBNull.Value),
                new SqlParameter("@aNHDAIDIEN", DBNull.Value),
                new SqlParameter("@eMAIL", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DANGNHAP),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_TaiKhoanDangNhap", par);
            foreach (DataRow item in dt.Rows)
            {
                TaiKhoanDangNhapModel mh = new TaiKhoanDangNhapModel();
                mh.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                mh.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                mh.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                mh.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                mh.GIOITINH = item["GIOITINH"].ToString();
                mh.MATAIKHOAN = int.Parse(item["MATAIKHOAN"].ToString());
                mh.TENDANGNHAP = item["TENDANGNHAP"].ToString();
                mh.MATKHAU = item["MATKHAU"].ToString();
                mh.PHANQUYEN = item["PHANQUYEN"].ToString();
                mh.ANHDAIDIEN = item["ANHDAIDIEN"].ToString();
                mh.EMAIL = item["EMAIL"].ToString();
                list.Add(mh);
            }
            return list;
        }

        public List<TaiKhoanDangNhapModel> DanhSach()
        {
            List<TaiKhoanDangNhapModel> list = new List<TaiKhoanDangNhapModel>();
            Object[] par = {
                new SqlParameter("@mATAIKHOAN", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENDANGNHAP", DBNull.Value),
                new SqlParameter("@mATKHAU", DBNull.Value),
                new SqlParameter("@pHANQUYEN", DBNull.Value),
                new SqlParameter("@aNHDAIDIEN", DBNull.Value),
                new SqlParameter("@eMAIL", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_TaiKhoanDangNhap", par);
            foreach (DataRow item in dt.Rows)
            {
                TaiKhoanDangNhapModel mh = new TaiKhoanDangNhapModel();
                mh.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                mh.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                mh.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                mh.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                mh.GIOITINH = item["GIOITINH"].ToString();
                mh.MATAIKHOAN = int.Parse(item["MATAIKHOAN"].ToString());
                mh.TENDANGNHAP = item["TENDANGNHAP"].ToString();
                mh.PHANQUYEN = item["PHANQUYEN"].ToString();
                mh.ANHDAIDIEN = item["ANHDAIDIEN"].ToString();
                mh.EMAIL = item["EMAIL"].ToString();
                list.Add(mh);
            }
            return list;
        }

        public TaiKhoanDangNhapModel TaiKhoanChiTiet()
        {
            TaiKhoanDangNhapModel rs = new TaiKhoanDangNhapModel();
            Object[] par = {
                new SqlParameter("@mATAIKHOAN", MATAIKHOAN),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENDANGNHAP", DBNull.Value),
                new SqlParameter("@mATKHAU", DBNull.Value),
                new SqlParameter("@pHANQUYEN", DBNull.Value),
                new SqlParameter("@aNHDAIDIEN", DBNull.Value),
                new SqlParameter("@eMAIL", DBNull.Value),
                new SqlParameter("@kEY", DBKey.FIND),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_TaiKhoanDangNhap", par);
            foreach (DataRow item in dt.Rows)
            {
                rs.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                rs.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                rs.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                rs.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                rs.GIOITINH = item["GIOITINH"].ToString();
                rs.MATAIKHOAN = int.Parse(item["MATAIKHOAN"].ToString());
                rs.TENDANGNHAP = item["TENDANGNHAP"].ToString();
                rs.PHANQUYEN = item["PHANQUYEN"].ToString();
                rs.ANHDAIDIEN = item["ANHDAIDIEN"].ToString();
                rs.EMAIL = item["EMAIL"].ToString();
            }
            return rs;
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mATAIKHOAN", MATAIKHOAN),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENDANGNHAP", TENDANGNHAP),
                new SqlParameter("@mATKHAU", MATKHAU),
                new SqlParameter("@pHANQUYEN", PHANQUYEN),
                new SqlParameter("@aNHDAIDIEN", ANHDAIDIEN),
                new SqlParameter("@eMAIL", EMAIL),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_TaiKhoanDangNhap", par).Rows[0][0].ToString());
        }
    }
}