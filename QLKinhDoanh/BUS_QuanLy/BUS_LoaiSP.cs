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
    public class BUS_LoaiSP
    {
        DAL_LoaiSP dalSP = new DAL_LoaiSP();
        public DataTable getSP()
        {
            return dalSP.getLoaiSP();
        }
        public bool themSP(DTO_LoaiSP sp)
        {
            return dalSP.themLoaiSP(sp);
        }
        public bool suaSP(DTO_LoaiSP sp)
        {
            return dalSP.suaLoaiSP(sp);
        }
        public bool xoaSP(int id)
        {
            return dalSP.xoaLoaiSP(id);
        }
    }
}
