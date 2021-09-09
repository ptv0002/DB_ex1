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

        }

        public int Id { get; set; }

        [Column("CardType")]
        [StringLength(10)]
        public string Name { get; set; }

        public double? PercentDiscount { get; set; }

        public bool Status { get; set; }
        public double LowerBound { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

    }
}
