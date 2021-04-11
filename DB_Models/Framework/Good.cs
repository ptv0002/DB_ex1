namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            InOut_Goods = new HashSet<InOut_Goods>();
        }

        [Key]
        public int goodsId { get; set; }

        public int? GoodsGroupId { get; set; }

        [StringLength(50)]
        [Required]
        public string GoodsName { get; set; }

        public bool? GoodsStatus { get; set; }

        [StringLength(20)]
        public string GoodsCode { get; set; }

        public int? MinQuantity { get; set; }

        public int? GoodsQuantity { get; set; }

        public double? ImportPrice { get; set; }

        public double? SalePrice { get; set; }

        public int? TaxPercent { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual Category Goods_Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InOut_Goods> InOut_Goods { get; set; }
    }
}
