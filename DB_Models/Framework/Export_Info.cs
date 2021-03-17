namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Export_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Export_Info()
        {
            InOut_Goods = new HashSet<InOut_Goods>();
        }

        [Key]
        public int exportInfoId { get; set; }

        public int? CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public double? TransactionScore { get; set; }

        public double? TotalExport { get; set; }

        public bool? PaymentStatus { get; set; }

        [StringLength(50)]
        public string PaymentType { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InOut_Goods> InOut_Goods { get; set; }
    }
}
