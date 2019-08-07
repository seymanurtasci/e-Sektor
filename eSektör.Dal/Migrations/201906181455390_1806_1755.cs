namespace eSektör.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1806_1755 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorize",
                c => new
                    {
                        AuthorizeId = c.Guid(nullable: false),
                        Type = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.AuthorizeId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Guid(nullable: false),
                        CompanyName = c.String(maxLength: 30, unicode: false),
                        ContactName = c.String(maxLength: 30, unicode: false),
                        Phone = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 20, unicode: false),
                        AverageScore = c.Decimal(precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        TaxNo = c.String(maxLength: 30, unicode: false),
                        AuthorizeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.Authorize", t => t.AuthorizeId)
                .Index(t => t.AuthorizeId);
            
            CreateTable(
                "dbo.MemberSpeciality",
                c => new
                    {
                        MemberSpecialityId = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        SpecialityId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberSpecialityId)
                .ForeignKey("dbo.Speciality", t => t.SpecialityId)
                .ForeignKey("dbo.Member", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.Speciality",
                c => new
                    {
                        SpecialityId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 40, unicode: false),
                        UpperSpeciality = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialityId)
                .ForeignKey("dbo.Speciality", t => t.UpperSpeciality)
                .Index(t => t.UpperSpeciality);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MemberId = c.Guid(nullable: false),
                        Detail = c.String(maxLength: 500, unicode: false),
                        CancellationReason = c.String(maxLength: 500, unicode: false),
                        IsCancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .ForeignKey("dbo.Member", t => t.MemberId)
                .Index(t => t.TaskId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.OfferDetail",
                c => new
                    {
                        OfferDetailId = c.Guid(nullable: false),
                        OffreId = c.Guid(nullable: false),
                        Brand = c.String(maxLength: 50, unicode: false),
                        Model = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 700, unicode: false),
                        UnitEnum = c.Int(nullable: false),
                        QuantityUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OfferDetailId)
                .ForeignKey("dbo.Offers", t => t.OffreId)
                .Index(t => t.OffreId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        OfferId = c.Guid(),
                        StartDatetime = c.DateTime(nullable: false),
                        EndDatetime = c.DateTime(nullable: false),
                        Score = c.Decimal(precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        PaymentMethodId = c.Guid(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethodId)
                .ForeignKey("dbo.Member", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        PaymentMethodId = c.Guid(nullable: false),
                        Type = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "AuthorizeId", "dbo.Authorize");
            DropForeignKey("dbo.Task", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Offers", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Offers", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Task", "PaymentMethodId", "dbo.PaymentMethod");
            DropForeignKey("dbo.OfferDetail", "OffreId", "dbo.Offers");
            DropForeignKey("dbo.MemberSpeciality", "MemberId", "dbo.Member");
            DropForeignKey("dbo.MemberSpeciality", "SpecialityId", "dbo.Speciality");
            DropForeignKey("dbo.Speciality", "UpperSpeciality", "dbo.Speciality");
            DropIndex("dbo.Task", new[] { "PaymentMethodId" });
            DropIndex("dbo.Task", new[] { "MemberId" });
            DropIndex("dbo.OfferDetail", new[] { "OffreId" });
            DropIndex("dbo.Offers", new[] { "MemberId" });
            DropIndex("dbo.Offers", new[] { "TaskId" });
            DropIndex("dbo.Speciality", new[] { "UpperSpeciality" });
            DropIndex("dbo.MemberSpeciality", new[] { "SpecialityId" });
            DropIndex("dbo.MemberSpeciality", new[] { "MemberId" });
            DropIndex("dbo.Member", new[] { "AuthorizeId" });
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.Task");
            DropTable("dbo.OfferDetail");
            DropTable("dbo.Offers");
            DropTable("dbo.Speciality");
            DropTable("dbo.MemberSpeciality");
            DropTable("dbo.Member");
            DropTable("dbo.Authorize");
        }
    }
}
