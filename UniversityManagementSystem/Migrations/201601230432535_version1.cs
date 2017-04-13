namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            AlterColumn("dbo.Courses", "TeacherId", c => c.Int());
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            AlterColumn("dbo.Courses", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
