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
    public class BUS_NSX
    {
        DAL_NSX dalNSX = new DAL_NSX();
        public DataTable getNSX()
        {
            return dalNSX.getNSX();
        }
        public bool themNSX(DTO_NhaSX nsx)
        {
            return dalNSX.themNSX(nsx);
        }
        public bool suaNSX(DTO_NhaSX nsx)
        {
            return dalNSX.suaNSX(nsx);
        }
        public bool xoaNSX(int id)
        {
            return dalNSX.xoaNSX(id);
        }
    }
}
