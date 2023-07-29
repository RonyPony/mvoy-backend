using mvoy.core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.DTOs
{
    public class LoginDto
    {
        public string email { get; set; }

        public string password { get; set; }
    }
}
