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
        public int Id { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public bool Status { get; set; }

        [StringLength(20)]
        public string Barcode { get; set; }

        public int MinQuantity { get; set; }

        public int Quantity { get; set; }

        public double ImportPrice { get; set; }

        public double? SalePrice { get; set; }

        public double Tax { get; set; }

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
