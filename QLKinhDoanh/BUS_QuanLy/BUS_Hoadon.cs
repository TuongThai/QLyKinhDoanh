using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_Hoadon
    {
        DAL_Hoadon dalHd = new DAL_Hoadon();
        public DataTable getHoadon()
        {
            return dalHd.getHoadon();
        }
        public DataTable getTheongay(string ngay)
        {
            return dalHd.getTheongay(ngay);
        }
        public bool themHD(DTO_Hoadon hd)
        {
            return dalHd.themHoadon(hd);
        }
        public bool xoaHD(int id)
        {
            return dalHd.xoaHoadon(id);
        }
    }
}
