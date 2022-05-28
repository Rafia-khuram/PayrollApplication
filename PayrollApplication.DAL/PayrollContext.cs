using PayrollApplication.BOL;
using PayrollApplication.BOL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PayrollApplication.DAL
{ 
    public class PayrollContext:DbContext
    {

        public PayrollContext() : base("ConnectionString")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentStatus> PaymentStatuses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<SalarySheet> SalarySheets { get; set; }
    public DbSet<SalaryType> SalaryTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Gender> Genders { get; set; }
  
   
    }
}