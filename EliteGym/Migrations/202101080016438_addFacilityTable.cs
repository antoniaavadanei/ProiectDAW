namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFacilityTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Name", c => c.String());
        }
    }
}
