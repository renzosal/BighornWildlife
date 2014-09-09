namespace BighornWildlife.API.Migrations.BighornContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSightingEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sightings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecieId = c.Int(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Species", t => t.SpecieId, cascadeDelete: true)
                .Index(t => t.SpecieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sightings", "SpecieId", "dbo.Species");
            DropIndex("dbo.Sightings", new[] { "SpecieId" });
            DropTable("dbo.Sightings");
        }
    }
}
