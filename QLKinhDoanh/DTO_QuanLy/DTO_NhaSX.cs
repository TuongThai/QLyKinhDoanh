using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhaSX
    {
        private int id_Nhasx;
        private string tenNSX;
        private string diaChi;

        public int Id_Nhasx { get => id_Nhasx; set => id_Nhasx = value; }
        public string TenNSX { get => tenNSX; set => tenNSX = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public DTO_NhaSX() { }
        public DTO_NhaSX(int i, string t, string d)
        {
            this.Id_Nhasx = i;
            this.TenNSX = t;
            this.DiaChi = d;
        }
    }
}
