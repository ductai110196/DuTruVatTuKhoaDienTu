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
    public class NamHocModel : iNamHoc
    {
        public int MSNAMHOC { get; set; }
        public string TENNAMHOC { get; set; }

        public NamHocModel(int mSNAMHOC, string tENNAMHOC)
        {
            MSNAMHOC = mSNAMHOC;
            TENNAMHOC = tENNAMHOC;
        }

        public NamHocModel()
        {
        }

        public List<NamHocModel> DanhSach()
        {
            List<NamHocModel> list = new List<NamHocModel>();
            Object[] par = {
                new SqlParameter("@mSNAMHOC", DBNull.Value),
                new SqlParameter("@tENNAMHOC", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_NamHoc", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new NamHocModel(
                            int.Parse(item["MSNAMHOC"].ToString()),
                            item["TENNAMHOC"].ToString())
                            );
            }
            return list;
        }

        public List<NamHocModel> KiemTraNamHoc()
        {
            List<NamHocModel> list = new List<NamHocModel>();
            Object[] par = {
                new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@tENNAMHOC", TENNAMHOC),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_NamHoc", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new NamHocModel(
                            int.Parse(item["MSNAMHOC"].ToString()),
                            item["TENNAMHOC"].ToString())
                            );
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSNAMHOC", DBNull.Value),
                new SqlParameter("@tENNAMHOC", TENNAMHOC),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NamHoc", par).Rows[0][0].ToString());
        }

        public int CapNhatNamHoc()
        {
            Object[] par = {
                 new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@tENNAMHOC", TENNAMHOC),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NamHoc", par).Rows[0][0].ToString());
        }

        public int XoaNamHoc()
        {
            Object[] par = {
                 new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@tENNAMHOC", TENNAMHOC),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NamHoc", par).Rows[0][0].ToString());
        }
    }
}