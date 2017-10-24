using DuTruVatTu.Database;
using DuTruVatTu.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DuTruVatTu.Models
{
    public class MonHocModel : iMonHoc, iBacDaoTao
    {
        public int MSHOCPHAN { get; set; }
        public string MAHOCPHAN { get; set; }
        public string TENHOCPHAN { get; set; }
        public int LYTHUYET { get; set; }
        public int THUCHANH { get; set; }
        public int MSBACDAOTAO { get; set; }
        public string TENBACDAOTAO { get; set; }

        public MonHocModel()
        {
        }

        public MonHocModel(int mSHOCPHAN, string mAHOCPHAN, int lYTHUYET, int tHUCHANH, int mSBACDAOTAO, string tENBACDAOTAO)
        {
            MSHOCPHAN = mSHOCPHAN;
            MAHOCPHAN = mAHOCPHAN;
            LYTHUYET = lYTHUYET;
            THUCHANH = tHUCHANH;
            MSBACDAOTAO = mSBACDAOTAO;
            TENBACDAOTAO = tENBACDAOTAO;
        }

        public List<MonHocModel> DanhSach()
        {
            List<MonHocModel> list = new List<MonHocModel>();
            Object[] par = {
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@mAHOCPHAN", DBNull.Value),
                new SqlParameter("@mSBACDAOTAO", MSBACDAOTAO),
                new SqlParameter("@tENHOCPHAN", DBNull.Value),
                new SqlParameter("@lYTHUYET", DBNull.Value),
                new SqlParameter("@tHUCHANH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_MonHoc", par);
            foreach (DataRow item in dt.Rows)
            {
                MonHocModel mh = new MonHocModel();
                mh.MSHOCPHAN = int.Parse(item["MSHOCPHAN"].ToString());
                mh.MAHOCPHAN = item["MAHOCPHAN"].ToString();
                mh.TENHOCPHAN = item["TENHOCPHAN"].ToString();
                mh.LYTHUYET = int.Parse(item["LYTHUYET"].ToString());
                mh.THUCHANH = int.Parse(item["THUCHANH"].ToString());
                mh.MSBACDAOTAO = int.Parse(item["MSBACDAOTAO"].ToString());
                mh.TENBACDAOTAO = item["TENBACDAOTAO"].ToString();
                list.Add(mh);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@mAHOCPHAN", MAHOCPHAN),
                new SqlParameter("@mSBACDAOTAO", MSBACDAOTAO),
                new SqlParameter("@tENHOCPHAN", TENHOCPHAN),
                new SqlParameter("@lYTHUYET", LYTHUYET),
                new SqlParameter("@tHUCHANH", THUCHANH),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_MonHoc", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@mAHOCPHAN", MAHOCPHAN),
                new SqlParameter("@mSBACDAOTAO", MSBACDAOTAO),
                new SqlParameter("@tENHOCPHAN", TENHOCPHAN),
                new SqlParameter("@lYTHUYET", LYTHUYET),
                new SqlParameter("@tHUCHANH", THUCHANH),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_MonHoc", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@mAHOCPHAN", DBNull.Value),
                new SqlParameter("@mSBACDAOTAO", DBNull.Value),
                new SqlParameter("@tENHOCPHAN", DBNull.Value),
                new SqlParameter("@lYTHUYET", DBNull.Value),
                new SqlParameter("@tHUCHANH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_MonHoc", par).Rows[0][0].ToString());
        }

        public List<MonHocModel> KiemTraMonHoc()
        {
            List<MonHocModel> list = new List<MonHocModel>();
            Object[] par = {
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@mAHOCPHAN", DBNull.Value),
                new SqlParameter("@mSBACDAOTAO", DBNull.Value),
                new SqlParameter("@tENHOCPHAN", DBNull.Value),
                new SqlParameter("@lYTHUYET", DBNull.Value),
                new SqlParameter("@tHUCHANH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_MonHoc", par);
            foreach (DataRow item in dt.Rows)
            {
                MonHocModel mh = new MonHocModel();
                MSHOCPHAN = int.Parse(item["MSHOCPHAN"].ToString());
                MAHOCPHAN = item["MAHOCPHAN"].ToString();
                TENHOCPHAN = item["TENHOCPHAN"].ToString();
                LYTHUYET = int.Parse(item["LYTHUYET"].ToString());
                THUCHANH = int.Parse(item["THUCHANH"].ToString());
                MSBACDAOTAO = int.Parse(item["MSBACDAOTAO"].ToString());
                TENBACDAOTAO = item["TENBACDAOTAO"].ToString();
                list.Add(mh);
            }
            return list;
        }
    }
}