﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Image { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }
        public string Role { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
    }
}
