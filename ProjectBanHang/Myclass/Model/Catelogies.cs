using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Catelories")] 
    public  class Catelogies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Tên loại sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Tên loại rút gọn")]
        public string Slug { get; set; }
        [Display(Name = "Cấp cha")]
        public int? ParentId { get; set;}
        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string MetaDecs { get; set; }
        [Required]
        [Display(Name = "Từ khóa")]
        public String MetaKey { get; set; }
        [Display(Name = "Tạo bởi")]
        public int CreateBy { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }
        [Display(Name = "Cập nhập bởi")]
        public int UpdateBy { get; set; }
        [Display(Name = "Ngày cập nhập")]
        public DateTime UpdateAt { get; set; }
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }



    }
}
