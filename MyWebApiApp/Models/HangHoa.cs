using System;

namespace MyWebApiApp.Models
{

    // Muon gui len chi can gui ten voi don gia
    public class HangHoaVM
    {
        // clone Ctrl + D
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }

    // HangHoa: HangHoaVM =>  HangHoa ke thua tu  HangHoaVM o phai tren
    public class HangHoa: HangHoaVM
    {
        // clone Ctrl + D
        public Guid MaHangHoa { get; set; }
    };

    public class HangHoaModel
    {
        public Guid MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
        public string TenLoai { get; set; }

    }
}


