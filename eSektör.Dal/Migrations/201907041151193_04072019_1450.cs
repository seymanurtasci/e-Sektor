namespace eSektör.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04072019_1450 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Speciality", "UpperSpeciality", s => s.Guid(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
