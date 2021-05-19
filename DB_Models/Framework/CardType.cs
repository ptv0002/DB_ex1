namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardType")]
    public partial class CardType
    {
        public CardType()
        {
            Customers = new HashSet<Customer>();
        }

        public int id { get; set; }

        [Column("CardType")]
        [StringLength(10)]
        public string CardType1 { get; set; }

        public int PercentDiscount { get; set; }

        public double DecreaseBy { get; set; }

        public int LowerBound { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
