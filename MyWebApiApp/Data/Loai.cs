using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{


    [Table("Loai")]

    public class Loai
    {

        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        // mot loai thi no co nhieu  => dang array

        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
