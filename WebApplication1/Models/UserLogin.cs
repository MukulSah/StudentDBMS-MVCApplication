﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserLogin
    {
        [Required]
        public string EmailID { get; set; }

        [Required]
        public string Password { get; set; }
    }
}