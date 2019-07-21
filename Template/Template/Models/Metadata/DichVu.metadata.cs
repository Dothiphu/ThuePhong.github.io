using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Template.Models
{
    [MetadataTypeAttribute(typeof(DichVuMetadata))]
    public partial class DichVu
    {
        internal sealed class DichVuMetadata
        {
            [Display(Name = "Mã DV")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public int MaDV { get; set; }
            [Display(Name = "Tên DV")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string TenDV { get; set; }
            [Display(Name = "Giá DV")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string GiaDV { get; set; }
        }
    
    }
}