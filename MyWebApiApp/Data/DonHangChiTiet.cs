using System;

namespace MyWebApiApp.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHh { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }
        public string DonGia { get; set; }
        public byte GiamGia { get; set; }

        // Sau khi tao xong ta se di tao moi quan he
        // Relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }


    }
}


