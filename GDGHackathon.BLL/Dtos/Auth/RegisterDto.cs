﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.BLL.Dtos.Auth
{
    public class RegisterDto
    {
        public string UserName {  get; set; }
        public string Email {  get; set; }
        public string Address {  get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }          // User's role: "Farmer" or "Wholesaler"
    }
}
