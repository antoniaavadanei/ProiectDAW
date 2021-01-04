namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFacilityTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facilities", "ScheduleDay", c => c.String(nullable: false));
            AddColumn("dbo.Facilities", "ScheduleHour", c => c.String(nullable: false));
            DropColumn("dbo.Facilities", "Schedule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facilities", "Schedule", c => c.String(nullable: false));
            DropColumn("dbo.Facilities", "ScheduleHour");
            DropColumn("dbo.Facilities", "ScheduleDay");
        }
    }
}
