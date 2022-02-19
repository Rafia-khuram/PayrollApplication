namespace PayrollApplication.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(nullable: false),
                        CheckInTime = c.DateTime(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                        BreakStart = c.DateTime(nullable: false),
                        BreakEnd = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Image = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        GenderId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        AccessToken = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.GenderId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        FeedbackTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        SalaryId = c.Int(nullable: false),
                        PaymentStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentStatus", t => t.PaymentStatusId)
                .ForeignKey("dbo.Salaries", t => t.SalaryId)
                .Index(t => t.SalaryId)
                .Index(t => t.PaymentStatusId);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseSalary = c.Int(nullable: false),
                        Bonus = c.Int(nullable: false),
                        Deductions = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        AttendanceId = c.Int(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendances", t => t.AttendanceId)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.AttendanceId);
            
            CreateTable(
                "dbo.SalarySheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        SalaryTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.EmployeeId)
                .ForeignKey("dbo.SalaryTypes", t => t.SalaryTypeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.SalaryTypeId);
            
            CreateTable(
                "dbo.SalaryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalarySheets", "SalaryTypeId", "dbo.SalaryTypes");
            DropForeignKey("dbo.SalarySheets", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Payments", "SalaryId", "dbo.Salaries");
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Salaries", "AttendanceId", "dbo.Attendances");
            DropForeignKey("dbo.Payments", "PaymentStatusId", "dbo.PaymentStatus");
            DropForeignKey("dbo.FeedBacks", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.SalarySheets", new[] { "SalaryTypeId" });
            DropIndex("dbo.SalarySheets", new[] { "EmployeeId" });
            DropIndex("dbo.Salaries", new[] { "AttendanceId" });
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropIndex("dbo.Payments", new[] { "PaymentStatusId" });
            DropIndex("dbo.Payments", new[] { "SalaryId" });
            DropIndex("dbo.FeedBacks", new[] { "EmployeeId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropTable("dbo.SalaryTypes");
            DropTable("dbo.SalarySheets");
            DropTable("dbo.Salaries");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.Payments");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Roles");
            DropTable("dbo.Genders");
            DropTable("dbo.Users");
            DropTable("dbo.Attendances");
        }
    }
}
