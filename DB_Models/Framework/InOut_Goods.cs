namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InOut_Goods
    {
        [Key]
        public int inOutGoodsId { get; set; }

        public int? GoodsId { get; set; }

        public int? ImportInfoId { get; set; }

        public int? ExportInfoId { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        public double? TotalPrice { get; set; }

        public bool? InOutStatus { get; set; }

        public virtual Export_Info Export_Info { get; set; }

        public virtual Good Good { get; set; }

        public virtual Import_Info Import_Info { get; set; }
    }
}
