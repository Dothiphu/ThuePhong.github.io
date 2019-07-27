using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
     [MetadataTypeAttribute(typeof(PhongMetadata))]
    public partial class Phong
    {
         internal sealed class PhongMetadata
         {
             [Display(Name = "Mã Phòng")]
             [Required(ErrorMessage = "{0} không được bỏ trống")]
             public int MaPhong { get; set; }
             [Display(Name = "Tên Phòng")]
             [Required(ErrorMessage = "{0} không được bỏ trống")]
             public string TenPhong { get; set; }
             [Display(Name = "Giá Phòng")]
             [Required(ErrorMessage = "{0} không được bỏ trống")]
             public Nullable<int> GiaPhong { get; set; }
             [Display(Name = "Trạng Thái")]
             [Required(ErrorMessage = "{0} không được bỏ trống")]
             public Nullable<int> TrangThai { get; set; }
             [Display(Name = "Diện Tích")]
             [Required(ErrorMessage = "{0} không được bỏ trống")]
             public string DienTich { get; set; }

         }
    }
}