namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    [Serializable]
    public partial class Supplier
    {
        public Supplier()
        {
            Import_Info = new HashSet<Import_Info>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        public bool SupplierStatus { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string SupplierAddress { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual ICollection<Import_Info> Import_Info { get; set; }
    }
}
