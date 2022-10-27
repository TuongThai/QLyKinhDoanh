using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Kho
    {
        private int id_Kho;
        private int id_Loai;
        private int id_NSX;
        private string tenSP;
        private string loaiSP;
        private string tenNSX;
        private float gia;
        private int soLuong;

        public int Id_Kho { get => id_Kho; set => id_Kho = value; }
        public int Id_Loai { get => id_Loai; set => id_Loai = value; }
        public int Id_NSX { get => id_NSX; set => id_NSX = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string LoaiSP { get => loaiSP; set => loaiSP = value; }
        public string TenNSX { get => tenNSX; set => tenNSX = value; }
        public float Gia { get => gia; set => gia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public DTO_Kho() { }
        public DTO_Kho(int ikho, int iloai, int insx, string tsp, string lsp, string tnsx, float g, int sl)
        {
            this.Id_Kho = ikho;
            this.Id_Loai = iloai;
            this.Id_NSX = insx;
            this.TenSP = tsp;
            this.LoaiSP = lsp;
            this.TenNSX = tnsx;
            this.Gia = g;
            this.SoLuong = sl;
        }
    }
}
