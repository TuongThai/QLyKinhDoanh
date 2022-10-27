using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using DAL_QuanLy;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_Taikhoan
    {
        DAL_Taikhoan dalTaikhoan = new DAL_Taikhoan();
        public DataTable getTaikhoan()
        {
            return dalTaikhoan.getTaikhoan();
        }
        public bool themTaikhoan(DTO_Taikhoan tk)
        {
            return dalTaikhoan.themTaikhoan(tk);
        }
        public bool suaTaikhoan(DTO_Taikhoan tk)
        {
            return dalTaikhoan.suaTaikhoan(tk);
        }
        public bool xoaTaikhoan(string user)
        {
            return dalTaikhoan.xoaTaikhoan(user);
        }
    }
}
