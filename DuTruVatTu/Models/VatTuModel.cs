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
    public class VatTuModel : iVatTu, iNhomVatTu
    {
        public int MSNHOMVATTU { get; set; }
        public string TENNHOMVATTU { get; set; }
        public int MSVATTU { get; set; }
        public string TENVATTU { get; set; }
        public string DONVITINH { get; set; }
        public string HINHANH { get; set; }
        
        public VatTuModel()
        {
        }

        public VatTuModel(string tENNHOMVATTU, int mSVATTU, string tENVATTU, string dONVITINH, string hINHANH)
        {
            TENNHOMVATTU = tENNHOMVATTU;
            MSVATTU = mSVATTU;
            TENVATTU = tENVATTU;
            DONVITINH = dONVITINH;
            HINHANH = hINHANH;
        }

        public VatTuModel(int mSVATTU)
        {
            MSVATTU = mSVATTU;
        }

        public List<VatTuModel> DanhSach()
        {
            List<VatTuModel> list = new List<VatTuModel>();
            Object[] par = {
                new SqlParameter("@mSVATTU", DBNull.Value),
                new SqlParameter("@mSNHOMVATTU", MSNHOMVATTU),
                new SqlParameter("@tENVATTU", DBNull.Value),
                new SqlParameter("@dONVITINH", DBNull.Value),
                new SqlParameter("@hINHANH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_VatTu", par);
            foreach (DataRow item in dt.Rows)
            {
                VatTuModel vt = new VatTuModel();
                vt.MSNHOMVATTU = int.Parse(item["MSNHOMVATTU"].ToString());
                vt.TENNHOMVATTU = item["TENNHOMVATTU"].ToString();
                vt.MSVATTU = int.Parse(item["MSVATTU"].ToString());
                vt.TENVATTU = item["TENVATTU"].ToString();
                vt.DONVITINH = item["DONVITINH"].ToString();
                vt.HINHANH = item["HINHANH"].ToString();
                list.Add(vt);
            }
            return list;
        }

        public List<VatTuModel> KiemTra()
        {
            List<VatTuModel> list = new List<VatTuModel>();
            Object[] par = {
                new SqlParameter("@mSVATTU", DBNull.Value),
                new SqlParameter("@mSNHOMVATTU", DBNull.Value),
                new SqlParameter("@tENVATTU", this.TENVATTU),
                new SqlParameter("@dONVITINH", DBNull.Value),
                new SqlParameter("@hINHANH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_VatTu", par);
            foreach (DataRow item in dt.Rows)
            {
                VatTuModel vt = new VatTuModel();
                vt.MSNHOMVATTU = int.Parse(item["MSNHOMVATTU"].ToString());
                vt.TENNHOMVATTU = item["TENNHOMVATTU"].ToString();
                vt.MSVATTU = int.Parse(item["MSVATTU"].ToString());
                vt.TENVATTU = item["TENVATTU"].ToString();
                vt.DONVITINH = item["DONVITINH"].ToString();
                vt.HINHANH = item["HINHANH"].ToString();
                list.Add(vt);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSVATTU", DBNull.Value),
                new SqlParameter("@mSNHOMVATTU", MSNHOMVATTU),
                new SqlParameter("@tENVATTU", TENVATTU),
                new SqlParameter("@dONVITINH", DONVITINH),
                new SqlParameter("@hINHANH", HINHANH),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_VatTu", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@mSNHOMVATTU", MSNHOMVATTU),
                new SqlParameter("@tENVATTU", TENVATTU),
                new SqlParameter("@dONVITINH", DONVITINH),
                new SqlParameter("@hINHANH", HINHANH),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_VatTu", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@mSNHOMVATTU", DBNull.Value),
                new SqlParameter("@tENVATTU", DBNull.Value),
                new SqlParameter("@dONVITINH", DBNull.Value),
                new SqlParameter("@hINHANH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_VatTu", par).Rows[0][0].ToString());
        }
    }
}