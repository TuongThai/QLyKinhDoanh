using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Hoadon
    {
        private int id_Bill;
        private string ngay;
        private string nhanVien;
        private float thanhTien;

        public DTO_Hoadon() { }
        public DTO_Hoadon(int i, string n, string nv, float t)
        {
            this.Id_Bill = i;
            this.Ngay = n;
            this.NhanVien = nv;
            this.ThanhTien = t;
        }
        public int Id_Bill { get => id_Bill; set => id_Bill = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string NhanVien { get => nhanVien; set => nhanVien = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
