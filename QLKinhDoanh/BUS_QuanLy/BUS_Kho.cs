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
    public class BUS_Kho
    {
        DAL_Kho dalkho = new DAL_Kho();
        public DataTable getKho()
        {
            return dalkho.getKho();
        }
        public bool themKho(DTO_Kho sp)
        {
            return dalkho.themKho(sp);
        }
        public bool suaKho(DTO_Kho sp)
        {
            return dalkho.suaKho(sp);
        }
        public bool xoaKho(int id)
        {
            return dalkho.xoaKho(id);
        }
    }
}
