namespace DB_Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    [Serializable]
    public partial class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            Export_Info = new HashSet<Export_Info>();
            Import_Info = new HashSet<Import_Info>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public bool EmployeeStatus { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string EmployeeAddress { get; set; }
        [StringLength(20)]
        public string Position { get; set; }
        [StringLength(10)]
        public string EmployeeCode { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Export_Info> Export_Info { get; set; }

        public virtual ICollection<Import_Info> Import_Info { get; set; }
    }
}
