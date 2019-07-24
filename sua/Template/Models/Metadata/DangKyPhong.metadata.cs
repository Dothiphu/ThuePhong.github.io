using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Template.Models
{
    [MetadataTypeAttribute(typeof(DangKyPhongMetadata))]
    public partial class DangKyPhong
    {
        internal sealed class DangKyPhongMetadata
        {
            [Display(Name = "Mã Phòng")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public int MaPhong { get; set; }
            [Display(Name = "Mã KH")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public int MaKH { get; set; }
            [Display(Name = "Ngày BĐ")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string NgayBD { get; set; }
            [Display(Name = "Ngày KT")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string NgayKT { get; set; }
            [Display(Name = "Duyệt")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public Nullable<int> Duyet { get; set; }
            //[Display(Name = "Tên Phòng")]
            //[Required(ErrorMessage = "{0} không được bỏ trống")]
            //public string TenPhong { get; set; }
        }
    }
}