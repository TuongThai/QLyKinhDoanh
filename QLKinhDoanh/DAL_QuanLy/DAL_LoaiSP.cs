using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_LoaiSP : DBConnect
    {
        public DataTable getLoaiSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from LoaiSanPham", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool themLoaiSP(DTO_LoaiSP sp)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Insert into LoaiSanPham(LoaiSP)values('{0}')", sp.LoaiSp);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }catch(Exception e) { }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool suaLoaiSP(DTO_LoaiSP sp)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Update LoaiSanPham set LoaiSP = '{0}'where MaLoai='{1}'", sp.LoaiSp,sp.Id_sp);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e) { }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool xoaLoaiSP(int SP_id)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Delete from LoaiSanPham where MaLoai = '{0}'", SP_id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }catch(Exception e) { }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
