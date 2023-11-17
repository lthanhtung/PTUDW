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
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "MÃ loại sản phẩm không để trống")]
        [Display(Name = "Mã loại sản phẩm")]
        public int CatId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mã nhà cung cấp không để trống")]
        [Display(Name = "Mã nhà cung cấp")]
        public int SupplierId { get; set; }
        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }
    
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Giá nhâp không để trống")]
        [Display(Name = "Giá nhập")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Giá bán không để trống")]
        [Display(Name = "Giá bán")]
        public decimal PriceSale { get; set; }
        [Required(ErrorMessage = "Số lượng không để trống")]
        [Display(Name = "Số lượng")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "Mô tả không để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDecs { get; set; }
        [Required(ErrorMessage = "Từ khóa không để trống")]
        [Display(Name = "Từ khóa")]
        public string MetaKey { get; set; }
        [Required(ErrorMessage = "Người tạo không để trống")]
        [Display(Name = "Người tạo")]
        public int CreateBy { get; set; }
        [Required(ErrorMessage = "Ngày tạo không để trống")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }
        [Required(ErrorMessage ="Người cập nhập không để trống")]
        [Display(Name ="Người cập nhập")]
        public int UpdateBy { get; set; }
        [Required(ErrorMessage ="Ngày cập nhập không để trống")]
        [Display(Name ="Ngày cập nhập")]
        public DateTime UpdateAt { get; set; }
        [Required(ErrorMessage = "Trạng thái không để trống")]
        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
    }
}
