using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã KH")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public int MaKH { get; set; }
            [Display(Name = "Tên KH")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string TenKH { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string Diachi { get; set; }
            [Display(Name = "Số điện thoại")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string SDT { get; set; }
            [Display(Name = "Nghề nghiệp")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string Nghenghiep { get; set; }
            [Display(Name = "CMND")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string CMND { get; set; }

        }
    }
}