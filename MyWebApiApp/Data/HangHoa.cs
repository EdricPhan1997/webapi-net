using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Dinh nghia Entities

namespace MyWebApiApp.Data
{
    // tuong ung table 
    [Table("HangHoa")]
    public class HangHoa
    {

        [Key] // chi dinh MaHh la khoa chinh trong cai table dung [key]
        // hang hoa nhieu sai kieu Guid
        public Guid MaHh { get; set; }

        [Required] // bat buoc phai nhap
        [MaxLength(100)] // doi ta 100 kytu
        public string TenHh { get; set; }
        public string MoTa { get; set; }
        [Range(0, double.MaxValue)] // quy dinh tu 0 => toi da kieu double
        public double DonGia { get; set; }
        // byte :  tu 0 => 100 
        public byte GiamGia { get; set; }

        // Tao moi quan he
        //  int? khoa ngoai co the co the khong
        public int? MaLoai { get; set; }

        // Tao anh xa
        [ForeignKey("MaLoai")]
        // Dung o HangHoa muon lay Loai  chay vao Loai de lay dong 36
        public Loai Loai { get; set; }


        // quan he
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public HangHoa()
        {
            //  tao DonHangChiTiets voi gia tri ban dau la []
            // dung List == HashSet
            DonHangChiTiets = new List<DonHangChiTiet>();
        }

    }
}
