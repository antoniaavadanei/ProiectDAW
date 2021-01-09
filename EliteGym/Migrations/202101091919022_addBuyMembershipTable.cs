namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBuyMembershipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyMemberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        MembershipId = c.Int(nullable: false),
                        FacilityId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Facilities", t => t.FacilityId, cascadeDelete: true)
                .ForeignKey("dbo.Memberships", t => t.MembershipId, cascadeDelete: true)
                .Index(t => t.MembershipId)
                .Index(t => t.FacilityId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyMemberships", "MembershipId", "dbo.Memberships");
            DropForeignKey("dbo.BuyMemberships", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.BuyMemberships", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BuyMemberships", new[] { "ApplicationUserId" });
            DropIndex("dbo.BuyMemberships", new[] { "FacilityId" });
            DropIndex("dbo.BuyMemberships", new[] { "MembershipId" });
            DropTable("dbo.BuyMemberships");
        }
    }
}
