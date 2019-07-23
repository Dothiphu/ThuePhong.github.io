using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
     [MetadataTypeAttribute(typeof(ChiTietMetadata))]
    public partial class ChiTiet
    {
        internal sealed class ChiTietMetadata
        {
            [Display(Name = "Mã Phòng")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public int MaPhong { get; set; }
            [Display(Name = "Mã DV")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public int MaDV { get; set; }
            [Display(Name = "Đơn Giá")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public Nullable<int> DonGia { get; set; }
            [Display(Name = "Số Lượng")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public Nullable<int> SoLuong { get; set; }
            [Display(Name = "Thành Tiền")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public Nullable<int> ThanhTien {
                get
                {
                    return SoLuong * DonGia;
                }
            
            }
            [Display(Name = "Giá Phòng")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public Nullable<int> GiaPhong { get; set; }
            [Display(Name = "Tổng Tiền")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public Nullable<int> TongTien {
                get
                {
                    return ThanhTien + GiaPhong;
                }
            
            }
            [Display(Name = "Ngày BĐ")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string NgayBD { get; set; }
            [Display(Name = "Ngày KT")]
            [Required(ErrorMessage = "{0} không được bỏ trống")]
            public string NgayKT { get; set; }
    

        }
    }
}