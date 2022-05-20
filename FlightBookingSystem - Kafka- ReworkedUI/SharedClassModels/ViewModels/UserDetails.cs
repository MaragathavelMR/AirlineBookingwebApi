using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClassModels.ViewModels
{
    public  class UserDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
