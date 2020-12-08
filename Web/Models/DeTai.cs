﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DeTai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeTai()
        {
            this.NguoiDungs = new HashSet<NguoiDung>();
        }
    
        public int ID { get; set; }

        [Display(Name ="Tên đề tài")]
        [Required(ErrorMessage ="{0} bắt buộc nhập")]
        public string TenDeTai { get; set; }

        [Display(Name = "Yêu cầu đề tài")]
        [Required(ErrorMessage = "{0} bắt buộc nhập")]
        public string YeuCauDeTai { get; set; }

        [Display(Name = "Thời gian bắt đầu")]
        [Required(ErrorMessage = "{0} bắt buộc nhập")]
        public Nullable<System.DateTime> ThoiGianBatDau { get; set; }

        [Display(Name = "Thời gian kết thúc")]
        [Required(ErrorMessage = "{0} bắt buộc nhập")]
        public Nullable<System.DateTime> ThoiGianKetThuc { get; set; }

        [Display(Name = "Sồ tuần thực hiện")]
        public Nullable<int> SoTuanThucHien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
