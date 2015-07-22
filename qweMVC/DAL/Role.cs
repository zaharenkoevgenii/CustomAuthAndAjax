﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qweMVC.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}