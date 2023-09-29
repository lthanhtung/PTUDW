using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Posts")]
    public class Posts
    {
        public int Id { get; set; }
        [Required]
        public int? TopId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Slud { get; set; }
        public string Detail { get; set; }
        
        public string Image { get; set; }
        
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }
    }
}
