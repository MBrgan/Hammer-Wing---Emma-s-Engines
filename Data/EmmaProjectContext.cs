using EmmaProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Threading.Tasks;

namespace EmmaProject.Data
{
    public class EmmaProjectContext : DbContext
    {
        public EmmaProjectContext(DbContextOptions<EmmaProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmpLogin> EmpLogins { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<InvoicePayment> InvoicePayments { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }
        public DbSet<OrderRequestInventory> OrderRequestInventories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //EmployeePosition
            //Many to Many Primary Key
            modelBuilder.Entity<EmployeePosition>()
                .HasKey(p => new { p.EmpID, p.PosID });

            //EmployeePosition to Employee one to many
            modelBuilder.Entity<EmployeePosition>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeePositions)
                .HasForeignKey(c => c.EmpID);

            //EmployeePosition to Position one to many
            modelBuilder.Entity<EmployeePosition>()
                .HasOne(e => e.Position)
                .WithMany(e => e.EmployeePositions)
                .HasForeignKey(c => c.PosID);


            //InvoicePayment
            //Many to Many Primary Key
            modelBuilder.Entity<InvoicePayment>()
                .HasKey(p => new { p.InvoiceID, p.PaymentID });

            //InvoicePayment to Invoice one to many
            modelBuilder.Entity<InvoicePayment>()
                .HasOne(i => i.Invoice)
                .WithMany(i => i.InvoicePayments)
                .HasForeignKey(i => i.InvoiceID);

            //InvoicePayment to Payment one to many
            modelBuilder.Entity<InvoicePayment>()
                .HasOne(i => i.Payment)
                .WithMany(i => i.InvoicePayments)
                .HasForeignKey(i => i.PaymentID);


            //OrderRequestInventory
            //Many to Many Primary Key
            modelBuilder.Entity<OrderRequestInventory>()
                .HasKey(p => new { p.OrderRequestID, p.UPC_ID });

            //OrderRequestInventory to OrderRequest one to many
            modelBuilder.Entity<OrderRequestInventory>()
                .HasOne(i => i.OrderRequest)
                .WithMany(i => i.OrderRequestInventories)
                .HasForeignKey(i => i.OrderRequestID);

            //OrderRequestInventory to Inventory one to many
            modelBuilder.Entity<OrderRequestInventory>()
                .HasOne(i => i.Inventory)
                .WithMany(i => i.OrderRequestInventories)
                .HasForeignKey(i => i.UPC_ID);


            //InvoiceLine
            //Many to Many Primary Key
            modelBuilder.Entity<InvoiceLine>()
                .HasKey(p => new { p.InvoiceID, p.UPC_ID });

            //InvoiceLine to inventory one to one
            modelBuilder.Entity<InvoiceLine>()
                .HasOne(e => e.Inventory)
                .WithOne(e => e.InvoiceLine)
                .HasForeignKey<InvoiceLine>(i => i.UPC_ID);

            //InvoiceLine to Invoice one to one
            modelBuilder.Entity<InvoiceLine>()
                .HasOne(e => e.Invoice)
                .WithOne(e => e.InvoiceLine)
                .HasForeignKey<InvoiceLine>(i => i.InvoiceID);


            //Employee
            //Employee to invoice, many to one
            modelBuilder.Entity<Employee>()
                .HasMany<Invoice>(e => e.Invoices)
                .WithOne(i => i.Employee)
                .HasForeignKey(i => i.EmpID);

            //Employee to EmpLogin, many to one
            modelBuilder.Entity<Employee>()
                .HasMany<EmpLogin>(e => e.EmpLogins)
                .WithOne(i => i.Employee)
                .HasForeignKey(i => i.EmpID);


            //Invoice
            //Invoice to customer one to many
            modelBuilder.Entity<Invoice>()
                .HasOne(e => e.Customer)
                .WithMany(i => i.Invoices)
                .HasForeignKey(i => i.EmpID);


            //Customer
            //Customer to OrderRequest many to one
            modelBuilder.Entity<Customer>()
                .HasMany<OrderRequest>(e => e.OrderRequests)
                .WithOne(i => i.Customer)
                .HasForeignKey(i => i.CustID);

            //Inventory to Price many to one
            modelBuilder.Entity<Inventory>()
                .HasMany<Price>(e => e.Prices)
                .WithOne(i => i.Inventory)
                .HasForeignKey(i => i.UPC_ID);


            //Price
            //Inventory to Price many to one
            modelBuilder.Entity<Price>()
                .HasOne(e => e.Supplier)
                .WithMany(i => i.Prices)
                .HasForeignKey(i => i.SupID);

            //because the primary keys use a name like "SupID" instead of just "ID" they need to all be defined like this

            modelBuilder.Entity<Customer>()
                .HasKey(p => p.CustID);

            modelBuilder.Entity<EmpLogin>()
                .HasKey(p => p.LogID);

            modelBuilder.Entity<Invoice>()
                .HasKey(p => p.InvoiceID);

            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentID);

            modelBuilder.Entity<OrderRequest>()
                .HasKey(p => p.OrderRequestID);

            modelBuilder.Entity<Price>()
                .HasKey(p => p.PriceID);

            modelBuilder.Entity<Supplier>()
                .HasKey(p => p.SupID);

            modelBuilder.Entity<Employee>()
                .HasKey(p => p.EmpID);

            modelBuilder.Entity<Position>()
                .HasKey(p => p.PosTitle);

            modelBuilder.Entity<Inventory>()
                .HasKey(p => p.UPC_ID);
        }
    }
}
