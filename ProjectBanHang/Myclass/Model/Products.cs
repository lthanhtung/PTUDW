using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Products")]
    public class Products
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Supplier { get; set; }

        public string Slug { get; set; }
        [Required]
        public string Detail { get; set; }
        
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Qty { get; set; }
        public int Amount { get; set; }

        public string MetaDecs { get; set; }
        [Required]
        public string MetaKey { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Status { get; set; }
    }
}
