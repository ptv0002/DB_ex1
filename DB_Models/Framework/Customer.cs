namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    [Serializable]
    public partial class Customer
    {
        public Customer()
        {
            Export_Info = new HashSet<Export_Info>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public bool Status { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(20)]
        public string CitizenId { get; set; }

        public double MembershipScore { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }
        public virtual ICollection<Export_Info> Export_Info { get; set; }
    }
}
