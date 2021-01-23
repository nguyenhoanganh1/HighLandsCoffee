namespace WindowsFormsApp2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuGiaoHang")]
    public partial class PhieuGiaoHang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(150)]
        public string TenSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public DateTime? NgayGiao { get; set; }

        [StringLength(350)]
        public string GhiChu { get; set; }

        public int? maNCC { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
