using System;
using System.Collections.Generic;
using System.Text;

namespace MyFridgeManager.Models
{
    public class LoginUser
    {
        private int v1;
        private string v2;
        private string v3;

        public LoginUser(int v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }


    }
}
