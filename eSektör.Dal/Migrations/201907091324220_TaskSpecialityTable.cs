namespace eSektör.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskSpecialityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskSpeciality",
                c => new
                    {
                        SpecialityId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpecialityId, t.TaskId })
                .ForeignKey("dbo.Speciality", t => t.SpecialityId, cascadeDelete: true)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.SpecialityId)
                .Index(t => t.TaskId);
            
            AddColumn("dbo.Speciality", "TaskId", c => c.Guid(nullable: false));
            AddColumn("dbo.Task", "SpecialityId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskSpeciality", "TaskId", "dbo.Task");
            DropForeignKey("dbo.TaskSpeciality", "SpecialityId", "dbo.Speciality");
            DropIndex("dbo.TaskSpeciality", new[] { "TaskId" });
            DropIndex("dbo.TaskSpeciality", new[] { "SpecialityId" });
            DropColumn("dbo.Task", "SpecialityId");
            DropColumn("dbo.Speciality", "TaskId");
            DropTable("dbo.TaskSpeciality");
        }
    }
}
