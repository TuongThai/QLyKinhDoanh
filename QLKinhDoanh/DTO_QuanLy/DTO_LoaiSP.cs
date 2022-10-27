using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoaiSP
    {
        private int id_sp;
        private string loaiSp;

        public int Id_sp { get => id_sp; set => id_sp = value; }
        public string LoaiSp { get => loaiSp; set => loaiSp = value; }
        public DTO_LoaiSP() { }
        public DTO_LoaiSP(int i, string l)
        {
            this.Id_sp = i;
            this.LoaiSp = l;
        }
    }
}
