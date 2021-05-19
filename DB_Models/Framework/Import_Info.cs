namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Serializable]
    public partial class Import_Info
    {
        public Import_Info()
        {
            Import_Goods = new HashSet<Import_Goods>();
        }

        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string SupplierName { get; set; }

        public double TotalImport { get; set; }

        public bool PaymentStatus { get; set; }

        [StringLength(50)]
        public string PaymentType { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Import_Goods> Import_Goods { get; set; }
    }
}
