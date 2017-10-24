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
    public class NhomVatTuModel : iNhomVatTu, iNhomLinhVuc
    {
        public int MSNHOMVATTU { get; set; }
        public string TENNHOMVATTU { get; set; }
        public int MSNHOMLINHVUC { get; set; }
        public string TENNHOMLINHVUC { get; set; }

        public NhomVatTuModel()
        {
        }

        public NhomVatTuModel(int mSNHOMVATTU, string tENNHOMVATTU, int mSNHOMLINHVUC, string tENNHOMLINHVUC)
        {
            MSNHOMVATTU = mSNHOMVATTU;
            TENNHOMVATTU = tENNHOMVATTU;
            MSNHOMLINHVUC = mSNHOMLINHVUC;
            TENNHOMLINHVUC = tENNHOMLINHVUC;
        }

        public List<NhomVatTuModel> DanhSach()
        {
            List<NhomVatTuModel> list = new List<NhomVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSNHOMVATTU", DBNull.Value),
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMVATTU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_NhomVatTu", par);
            foreach (DataRow item in dt.Rows)
            {
                NhomVatTuModel nlv = new NhomVatTuModel();
                nlv.MSNHOMVATTU = int.Parse(item["MSNHOMVATTU"].ToString());
                nlv.TENNHOMVATTU = item["TENNHOMVATTU"].ToString();
                nlv.MSNHOMLINHVUC = int.Parse(item["MSNHOMLINHVUC"].ToString()); ;
                nlv.TENNHOMLINHVUC = item["TENNHOMLINHVUC"].ToString();
                list.Add(nlv);
            }
            return list;
        }

        public List<NhomVatTuModel> KiemTra()
        {
            List<NhomVatTuModel> list = new List<NhomVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSNHOMVATTU", DBNull.Value),
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMVATTU", TENNHOMVATTU),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_NhomVatTu", par);
            foreach (DataRow item in dt.Rows)
            {
                NhomVatTuModel nlv = new NhomVatTuModel();
                nlv.MSNHOMVATTU = int.Parse(item["MSNHOMVATTU"].ToString());
                nlv.TENNHOMVATTU = item["TENNHOMVATTU"].ToString();
                nlv.MSNHOMLINHVUC = int.Parse(item["MSNHOMLINHVUC"].ToString()); ;
                nlv.TENNHOMLINHVUC = nlv.TENNHOMVATTU = item["TENNHOMLINHVUC"].ToString();
                list.Add(nlv);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSNHOMVATTU", DBNull.Value),
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMVATTU", TENNHOMVATTU),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NhomVatTu", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSNHOMVATTU", MSNHOMVATTU),
                new SqlParameter("@mSNHOMLINHVUC", MSNHOMLINHVUC),
                new SqlParameter("@tENNHOMVATTU", TENNHOMVATTU),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NhomVatTu", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSNHOMVATTU", MSNHOMVATTU),
                new SqlParameter("@mSNHOMLINHVUC", DBNull.Value),
                new SqlParameter("@tENNHOMVATTU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_NhomVatTu", par).Rows[0][0].ToString());
        }
    }
}