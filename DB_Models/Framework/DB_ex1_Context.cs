using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DB_Models.Framework
{
    public partial class DB_ex1_Context : DbContext
    {
        public DB_ex1_Context()
            : base("name=DB_ex1_Context")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Export_Info> Export_Info { get; set; }
        public virtual DbSet<Export_Goods> Export_Goods { get; set; }
        public virtual DbSet<Fixed_variable> Fixed_variable { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Import_Info> Import_Info { get; set; }
        public virtual DbSet<Import_Goods> Import_Goods { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.AccPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<CardType>()
                .Property(e => e.CardType1)
                .IsUnicode(false);

            modelBuilder.Entity<CardType>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<CardType>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CitizenId)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Export_Info>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<Export_Info>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Export_Info>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Fixed_variable>()
                .Property(e => e.VariableName)
                .IsUnicode(false);

            modelBuilder.Entity<Fixed_variable>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Fixed_variable>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.GoodsName)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.GoodsCode)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Import_Info>()
                .Property(e => e.PaymentType)
                .IsUnicode(false);

            modelBuilder.Entity<Import_Info>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Import_Info>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);
        }
    }
}
