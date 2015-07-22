﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qweMVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }


        public virtual ICollection<Role> Roles { get; set; }
    }
}