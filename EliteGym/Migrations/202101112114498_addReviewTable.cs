namespace EliteGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StaffReview = c.Int(nullable: false),
                        CleanlinessScore = c.Int(nullable: false),
                        OverallExperienceReview = c.Int(nullable: false),
                        ReviewInfo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facilities", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Id", "dbo.Facilities");
            DropIndex("dbo.Reviews", new[] { "Id" });
            DropTable("dbo.Reviews");
        }
    }
}
