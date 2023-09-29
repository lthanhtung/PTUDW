﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Contacts")]
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Fullname { get; set; }
        
        public string Phone { get; set; }
       
        public string Email { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public String Detail { get; set; }
       
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }



    }
}
