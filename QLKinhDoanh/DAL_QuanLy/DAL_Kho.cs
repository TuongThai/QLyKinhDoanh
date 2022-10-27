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
    public class DAL_Kho : DBConnect
    {
        public DataTable getKho()
        {
            string sql = "select * from Kho";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool themKho(DTO_Kho kh)
        {
            try
            {
                conn.Open();
                string sql = string.Format("insert into Kho(MaLoai, MaNSX, TenSP, LoaiSP, TenNSX, Gia, soluong)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",kh.Id_Loai,kh.Id_NSX,kh.TenSP,kh.LoaiSP, kh.TenNSX, kh.Gia,kh.SoLuong);
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
        public bool suaKho(DTO_Kho kh)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Update Kho set MaLoai = '{0}', MaNSX='{1}', TenSP ='{2}', LoaiSP='{3}', TenNSX='{4}',Gia='{5}',soluong='{6}' where Makho='{7}'", kh.Id_Loai,kh.Id_NSX,kh.TenSP,kh.LoaiSP,kh.TenNSX,kh.Gia,kh.SoLuong,kh.Id_Kho);
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
        public bool xoaKho(int id)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Delete from Kho where Makho = '{0}'", id);
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
    }
}
