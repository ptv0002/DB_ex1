namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Export_Info
    {
        public Export_Info()
        {
            Export_Goods = new HashSet<Export_Goods>();
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double TransactionScore { get; set; }
        public bool CardDiscount { get; set; } 
        public double Total { get; set; }
        public double OtherDiscount { get; set; }
        public bool PaymentStatus { get; set; }
        [StringLength(50)]
        public string PaymentType { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(50)]
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [StringLength(50)]
        public string UpdateBy { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Export_Goods> Export_Goods { get; set; }
    }
}
