using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Models.Framework
{
    public partial class Export_Goods
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string GoodsName { get; set; }
        [StringLength(50)]
        public string Barcode { get; set; }

        public int ExportInfoId { get; set; }

        public int exQuantity { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public virtual Export_Info Export_Info { get; set; }

        public virtual Good Good { get; set; }
    }
}
