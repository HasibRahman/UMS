namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false, maxLength: 300, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                        SemisterId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Semisters", t => t.SemisterId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemisterId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 7, unicode: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.Semisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address = c.String(nullable: false, maxLength: 300, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        ContactNo = c.String(nullable: false, maxLength: 11, unicode: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        TakenCredit = c.Double(nullable: false),
                        RemainingCredit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "Email" });
            DropIndex("dbo.Departments", new[] { "Code" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "SemisterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropIndex("dbo.Courses", new[] { "Code" });
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.Semisters");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
