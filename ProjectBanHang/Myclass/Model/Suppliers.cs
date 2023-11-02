using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myclass.Model
{
    [Table("Suppliers")]
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không để trống")]
        [Display(Name = "Tên nhà cung cấp")]
        public string Name { get; set; }
        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }
        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }
        [Display(Name = "Tên đầy đủ")]
        public string FullName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không để trống")]

        public string MetaDecs { get; set; }
        [Display(Name = "Địa chỉ Website")]
        public string UrlSite { get; set; }
        [Display(Name = "Logo nhà cung cấp")]
        public string Image { get; set; }
        [Display(Name = "Từ khóa")]
        [Required(ErrorMessage = "Từ khóa sản phẩm không để trống")]

        public string MetaKey { get; set; }
        [Display(Name = "Người tạo")]
        public int CreateBy { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }
        [Display(Name = "Người cập nhập")]
        public int UpdateBy { get; set; }
        [Display(Name = "Ngày cập nhập")]
        public DateTime UpdateAt { get; set; }
        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }//Nếu sql là allow null thì int?
    }
}
