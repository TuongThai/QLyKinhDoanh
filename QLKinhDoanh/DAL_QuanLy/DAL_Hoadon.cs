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
    public class DAL_Hoadon : DBConnect
    {
        public DataTable getHoadon()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Hoadon", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getTheongay(string ngay)
        {
            string sql = string.Format("Select * from Hoadon where Ngay = '{0}'", ngay);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool themHoadon(DTO_Hoadon hd)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Insert into Hoadon(Ngay,Nhanvien,Thanhtien)values('{0}','{1}','{2}')", hd.Ngay,hd.NhanVien,hd.ThanhTien);
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
        public bool xoaHoadon(int HD_id)
        {
            try
            {
                conn.Open();
                string sql = string.Format("Delete from Hoadon where id_Bill = '{0}'", HD_id);
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
