namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        public int accId { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(20)]
        public string AccPassword { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }

        public virtual Employee Employee { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
    }
}
