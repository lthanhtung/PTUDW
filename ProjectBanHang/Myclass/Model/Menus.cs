using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Menus")]
    public class Menus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TableId { get; set; }
        public string TypeMenu { get; set; }
        public int? Order { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Link { get; set; }
        public string ParentId {  get; set; }

        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }

    }
}
