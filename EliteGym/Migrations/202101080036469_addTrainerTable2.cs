namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrainerTable2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trainers", "FacilityScheduleDay");
            DropColumn("dbo.Trainers", "FacilityScheduleHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "FacilityScheduleHour", c => c.String());
            AddColumn("dbo.Trainers", "FacilityScheduleDay", c => c.String());
        }
    }
}
