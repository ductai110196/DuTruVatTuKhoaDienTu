using DuTruVatTu.Database;
using DuTruVatTu.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DuTruVatTu.Models
{
    public class NhomLinhVucModel : iNhomLinhVuc
    {
        public int MSNHOMLINHVUC { get; set; }
        public string TENNHOMLINHVUC { get; set; }

        public NhomLinhVucModel()
        {
        }

        public NhomLinhVucModel(int mSNHOMLINHVUC)
        {
            MSNHOMLINHVUC = mSNHOMLINHVUC;
        }

        public NhomLinhVucModel(int mSNHOMLINHVUC, string tENNHOMLINHVUC)
        {
            MSNHOMLINHVUC = mSNHOMLINHVUC;
            TENNHOMLINHVUC = tENNHOMLINHVUC;
        }

        public List<NhomLinhVucModel> DanhSach()
        {
            List<NhomLinhVucModel> list = new List<NhomLinhVucModel>();
            Object[] par = {
                new SqlParameter("@mSNHOMLINHVUC", DBNull.Value),
                new SqlParameter("@tENNHOMLINHVUC", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_NhomLinhVuc", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new NhomLinhVucModel(
                            int.Parse(item["MSNHOMLINHVUC"].ToString()),
                            item["TENNHOMLINHVUC"].ToString()
                        ));
            }
            return list;
        }

        public List<NhomLinhVucModel> KiemTra()
        {
            List<NhomLinhVucModel> list = new List<NhomLinhVucModel>();
            Object[] par = {
                new SqlParameter("@mSNHOMLINHVUC", DBNull.Value),
                new SqlParameter("@tENNHOMLINHVUC", TENNHOMLINHVUC),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_NhomLinhVuc", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new NhomLinhVucModel(
                            int.Parse(item["MSNHOMLINHVUC"].ToString()),
                            item["TENNHOMLINHVUC"].ToString()
                        ));
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMLINHVUC", TENNHOMLINHVUC),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NhomLinhVuc", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMLINHVUC", TENNHOMLINHVUC),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NhomLinhVuc", par).Rows[0][0].ToString());
        }

        public int XoaNhomLinhVuc()
        {
            Object[] par = {
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMLINHVUC", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NhomLinhVuc", par).Rows[0][0].ToString());
        }
    }
}