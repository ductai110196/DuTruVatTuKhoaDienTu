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
    public class PhongModel : iPhong, iGiangVien
    {
        public PhongModel(int mSPHONG, string tENPHONG, int mSGIANGVIEN, string mAGIANGVIEN, string tENGIANGVIEN, DateTime nGAYSINH, string gIOITINH)
        {
            MSPHONG = mSPHONG;
            TENPHONG = tENPHONG;
            MSGIANGVIEN = mSGIANGVIEN;
            MAGIANGVIEN = mAGIANGVIEN;
            TENGIANGVIEN = tENGIANGVIEN;
            NGAYSINH = nGAYSINH;
            GIOITINH = gIOITINH;
        }

        public PhongModel(string tENPHONG)
        {
            TENPHONG = tENPHONG;
        }

        public PhongModel()
        {
        }

        public PhongModel(int mSPHONG)
        {
            MSPHONG = mSPHONG;
        }

        public PhongModel(int mSPHONG, string tENPHONG, int mSGIANGVIEN) : this(mSPHONG)
        {
            TENPHONG = tENPHONG;
            MSGIANGVIEN = mSGIANGVIEN;
        }

        public PhongModel(string tENPHONG, int mSGIANGVIEN)
        {
            TENPHONG = tENPHONG;
            MSGIANGVIEN = mSGIANGVIEN;
        }

        public int MSPHONG { get; set; }
        public string TENPHONG { get; set; }
        public int MSGIANGVIEN { get; set; }
        public string MAGIANGVIEN { get; set; }
        public string TENGIANGVIEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        
        public List<PhongModel> DanhSach()
        {
            List<PhongModel> list = new List<PhongModel>();
            Object[] par = {
                new SqlParameter("@mSPHONG", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENPHONG", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_Phong", par);
            foreach (DataRow item in dt.Rows)
            {
                PhongModel nlv = new PhongModel();
                nlv.MSPHONG = int.Parse(item["MSPHONG"].ToString());
                nlv.TENPHONG = item["TENPHONG"].ToString();
                nlv.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                nlv.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                nlv.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                list.Add(nlv);
            }
            return list;
        }

        public List<PhongModel> KiemTra()
        {
            List<PhongModel> list = new List<PhongModel>();
            Object[] par = {
                new SqlParameter("@mSPHONG", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENPHONG", TENPHONG),
                new SqlParameter("@kEY", DBKey.CHECK)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_Phong", par);
            foreach (DataRow item in dt.Rows)
            {
                PhongModel nlv = new PhongModel();
                nlv.MSPHONG = int.Parse(item["MSPHONG"].ToString());
                nlv.TENPHONG = item["TENPHONG"].ToString();
                nlv.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                list.Add(nlv);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSPHONG", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@tENPHONG", TENPHONG),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_Phong", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSPHONG", MSPHONG),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@tENPHONG", TENPHONG),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_Phong", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSPHONG", MSPHONG),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENPHONG", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_Phong", par).Rows[0][0].ToString());
        }
    }
}