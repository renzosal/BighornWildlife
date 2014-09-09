namespace BighornWildlife.API.Migrations.BighornContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateFieldtoSighting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sightings", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sightings", "Date");
        }
    }
}
