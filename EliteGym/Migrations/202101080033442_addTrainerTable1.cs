namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrainerTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "FacilityScheduleDay", c => c.String());
            AddColumn("dbo.Trainers", "FacilityScheduleHour", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "FacilityScheduleHour");
            DropColumn("dbo.Trainers", "FacilityScheduleDay");
        }
    }
}
