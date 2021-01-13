namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReservationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.Reservations", "MembershipId", "dbo.Memberships");
            DropForeignKey("dbo.Reservations", "FacilityId", "dbo.Facilities");
            DropForeignKey("dbo.Reservations", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUserId" });
            DropIndex("dbo.Reservations", new[] { "FacilityId" });
            DropIndex("dbo.Reservations", new[] { "MembershipId" });
            DropTable("dbo.Reservations");
        }
    }
}
