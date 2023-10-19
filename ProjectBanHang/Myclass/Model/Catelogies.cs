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
        [Required(ErrorMessage ="Tên loại sản phẩm không để trống")]
        [Display(Name ="Tên loại sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Tên loại rút gọn")]
        public string Slug { get; set; }
        [Display(Name = "Cấp cha")]
        public int? ParentId { get; set;}
        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }
        [Required(ErrorMessage = "Mô tả không để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDecs { get; set; }
        [Required(ErrorMessage = "Từ khóa  không để trống")]
        [Display(Name = "Từ khóa")]
        public String MetaKey { get; set; }
        [Display(Name = "Tạo bởi")]
        [Required(ErrorMessage = "Người tạo không để trống")]

        public int CreateBy { get; set; }
        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Ngày tạo không để trống")]

        public DateTime CreateAt { get; set; }
        [Display(Name = "Cập nhập bởi")]
        [Required(ErrorMessage = "Người cập nhập không để trống")]

        public int UpdateBy { get; set; }
        [Display(Name = "Ngày cập nhập")]
        [Required(ErrorMessage = "Ngày cập nhập không để trống")]

        public DateTime UpdateAt { get; set; }
        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Trạng thái không để trống")]
        public int Status { get; set; }



    }
}
