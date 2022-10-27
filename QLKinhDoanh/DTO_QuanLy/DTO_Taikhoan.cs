using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Taikhoan
    {
        private string username;
        private string password;
        private string name;
        private string state;
        private int type;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string State { get => state; set => state = value; }
        public int Type { get => type; set => type = value; }
        public DTO_Taikhoan() { }

        public DTO_Taikhoan(string user, string pass, string ten, string sta, int t)
        {
            this.Username = user;
            this.Password = pass;
            this.Name = ten;
            this.State = sta;
            this.Type = t;
        }
    }
}
