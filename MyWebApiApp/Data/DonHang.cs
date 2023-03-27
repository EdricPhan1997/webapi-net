using System;
using System.Collections.Generic;

namespace MyWebApiApp.Data
{
    public class DonHang
    {

        public enum TinhTrangDonDatHang
        {
            New = 0,
            Payment = 1,
            Completed = 2,
            Cancle = -1,
        }

        public Guid MaDh { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }


        //TinhTrangDonHang line 8
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai { get; set; }

        // quan he
        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DonHang()
        {
            //  tao DonHangChiTiets voi gia tri ban dau la []
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
