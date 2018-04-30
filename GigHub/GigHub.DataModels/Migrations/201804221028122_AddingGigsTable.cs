namespace GigHub.IdentityModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGigsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "FolloweeId" });
            DropTable("dbo.Gigs");
        }
    }
}
