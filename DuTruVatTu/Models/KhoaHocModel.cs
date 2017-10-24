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
    public class KhoaHocModel : iKhoaHoc
    {
        public int MSKHOAHOC { get; set; }
        public string TENKHOAHOC { get; set; }

        public KhoaHocModel(int mSKHOAHOC, string tENKHOAHOC)
        {
            MSKHOAHOC = mSKHOAHOC;
            TENKHOAHOC = tENKHOAHOC;
        }

        public KhoaHocModel()
        {
        }

        public List<KhoaHocModel> DanhSach()
        {
            List<KhoaHocModel> list = new List<KhoaHocModel>();
            Object[] par = {
                new SqlParameter("@mSKHOAHOC", DBNull.Value),
                new SqlParameter("@tENKHOAHOC", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_KhoaHoc", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new KhoaHocModel(
                            int.Parse(item["MSKHOAHOC"].ToString()),
                            item["TENKHOAHOC"].ToString()
                        ));
            }
            return list;
        }

        public List<KhoaHocModel> KiemTraKhoaHoc()
        {
            List<KhoaHocModel> list = new List<KhoaHocModel>();
            Object[] par = {
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENKHOAHOC", TENKHOAHOC),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_KhoaHoc", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new KhoaHocModel(
                            int.Parse(item["MSKHOAHOC"].ToString()),
                            item["TENKHOAHOC"].ToString()
                        ));
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSKHOAHOC", DBNull.Value),
                new SqlParameter("@tENKHOAHOC", TENKHOAHOC),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_KhoaHoc", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENKHOAHOC", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_KhoaHoc", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENKHOAHOC", TENKHOAHOC),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_KhoaHoc", par).Rows[0][0].ToString());
        }
    }
}