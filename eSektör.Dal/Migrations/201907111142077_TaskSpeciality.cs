namespace eSektör.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskSpeciality : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Speciality", "TaskId");
            DropColumn("dbo.Task", "SpecialityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Task", "SpecialityId", c => c.Guid(nullable: false));
            AddColumn("dbo.Speciality", "TaskId", c => c.Guid(nullable: false));
        }
    }
}
