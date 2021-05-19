namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            Import_Goods = new HashSet<Import_Goods>();
            Export_Goods = new HashSet<Export_Goods>();
        }

        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string categoryName { get; set; }

        [StringLength(50)]
        [Required]
        public string GoodsName { get; set; }

        public bool GoodsStatus { get; set; }

        [StringLength(20)]
        public string GoodsCode { get; set; }

        public int MinQuantity { get; set; }

        public int GoodsQuantity { get; set; }

        public double ImportPrice { get; set; }

        public double? SalePrice { get; set; }

        public double TaxPercent { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Import_Goods> Import_Goods { get; set; }
        public virtual ICollection<Export_Goods> Export_Goods { get; set; }
    }
}
