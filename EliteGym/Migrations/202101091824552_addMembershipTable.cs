namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Memberships", "FacilityId", "dbo.Facilities");
            DropIndex("dbo.Memberships", new[] { "FacilityId" });
            DropColumn("dbo.Memberships", "FacilityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memberships", "FacilityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Memberships", "FacilityId");
            AddForeignKey("dbo.Memberships", "FacilityId", "dbo.Facilities", "Id", cascadeDelete: true);
        }
    }
}
