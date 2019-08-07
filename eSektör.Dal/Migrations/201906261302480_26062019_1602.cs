namespace eSektör.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _26062019_1602 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "TaskTitle", c => c.String(nullable: false, maxLength: 70, unicode: false));
            DropColumn("dbo.OfferDetail", "OfferTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OfferDetail", "OfferTitle", c => c.String(maxLength: 70, unicode: false));
            DropColumn("dbo.Task", "TaskTitle");
        }
    }
}
