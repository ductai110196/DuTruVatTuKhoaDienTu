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
    public class PhanCongGiangDayModel : iPhanCongGiangDay, iGiangVien, iLopHocPhan, iMonHoc
    {
        public int MSLOPHOCPHAN { get; set; }
        public string MALOPHOCPHAN { get; set; }
        public string TENLOPHOCPHAN { get; set; }
        public int SISO { get; set; }
        public int LOAILOPHOCPHAN { get; set; }
        public int MSPHANCONGGIANGDAY { get; set; }
        public int MSGIANGVIEN { get; set; }
        public string MAGIANGVIEN { get; set; }
        public string TENGIANGVIEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public int MSHOCPHAN { get; set; }
        public string TENHOCPHAN { get; set; }
        public int LYTHUYET { get; set; }
        public int THUCHANH { get; set; }

        public PhanCongGiangDayModel()
        {
        }

        public PhanCongGiangDayModel(int mSLOPHOCPHAN, int mSPHANCONGGIANGDAY, int mSGIANGVIEN, int mSHOCPHAN)
        {
            MSLOPHOCPHAN = mSLOPHOCPHAN;
            MSPHANCONGGIANGDAY = mSPHANCONGGIANGDAY;
            MSGIANGVIEN = mSGIANGVIEN;
            MSHOCPHAN = mSHOCPHAN;
        }

        public PhanCongGiangDayModel(int mSPHANCONGGIANGDAY)
        {
            MSPHANCONGGIANGDAY = mSPHANCONGGIANGDAY;
        }


        public List<PhanCongGiangDayModel> DanhSach(string msHocKy, string maHocPhan)
        {
            List<PhanCongGiangDayModel> list = new List<PhanCongGiangDayModel>();
            Object[] par = {
                new SqlParameter("@mSPHANCONGGIANGDAY", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSHOCKY", msHocKy),
                new SqlParameter("@mSHOCPHAN", maHocPhan),
                new SqlParameter("@kEY", DBKey.SELECT_PHANCONGGIANGDAY),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_PhanCongGiangDay", par);
            foreach (DataRow item in dt.Rows)
            {
                PhanCongGiangDayModel pc = new PhanCongGiangDayModel();
                pc.MSLOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                pc.MALOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                pc.TENLOPHOCPHAN = item["TENLOPHOCPHAN"].ToString();
                pc.SISO = int.Parse(item["SISO"].ToString());
                pc.LOAILOPHOCPHAN = int.Parse(item["LOAILOPHOCPHAN"].ToString());
                pc.MSPHANCONGGIANGDAY = int.Parse(item["MSPHANCONGGIANGDAY"].ToString());
                pc.MSGIANGVIEN  = int.Parse(item["MSGIANGVIEN"].ToString());
                pc.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                pc.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                pc.MSHOCPHAN = int.Parse(item["MSHOCPHAN"].ToString());
                list.Add(pc);
            }
            return list;
        }

        public List<PhanCongGiangDayModel> DanhSachGiangVien(string msHocKy)
        {
            List<PhanCongGiangDayModel> list = new List<PhanCongGiangDayModel>();
            Object[] par = {
                new SqlParameter("@mSPHANCONGGIANGDAY", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSHOCKY", msHocKy),
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@kEY", DBKey.SELECT_PHANCONGGIANGDAY_GIANGVIEN),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_PhanCongGiangDay", par);
            foreach (DataRow item in dt.Rows)
            {
                PhanCongGiangDayModel pc = new PhanCongGiangDayModel();
                pc.MSLOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                pc.MALOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                pc.TENLOPHOCPHAN = item["TENLOPHOCPHAN"].ToString();
                pc.SISO = int.Parse(item["SISO"].ToString());
                pc.LOAILOPHOCPHAN = int.Parse(item["LOAILOPHOCPHAN"].ToString());
                pc.MSPHANCONGGIANGDAY = int.Parse(item["MSPHANCONGGIANGDAY"].ToString());
                pc.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                pc.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                pc.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                pc.MSHOCPHAN = int.Parse(item["MSHOCPHAN"].ToString());
                pc.TENHOCPHAN = item["TENHOCPHAN"].ToString();
                pc.LYTHUYET = int.Parse(item["LYTHUYET"].ToString());
                pc.THUCHANH = int.Parse(item["THUCHANH"].ToString());
                list.Add(pc);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSPHANCONGGIANGDAY", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_PhanCongGiangDay", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSPHANCONGGIANGDAY", MSPHANCONGGIANGDAY),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_PhanCongGiangDay", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSPHANCONGGIANGDAY", MSPHANCONGGIANGDAY),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_PhanCongGiangDay", par).Rows[0][0].ToString());
        }
    }
}