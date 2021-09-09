using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DB_Models.Framework
{
    
    [Serializable]
    public partial class Import_Goods
    {
        [Key]
        public int Id { get; set; }
        public int ImportInfoId { get; set; }
        [StringLength (50)]
        public string GoodsName { get; set; }
        [StringLength(50)]
        public string Barcode { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double? Discount { get; set; }
        public double TotalPrice { get; set; }

        public virtual Good Good { get; set; }

        public virtual Import_Info Import_Info { get; set; }

    }
}

