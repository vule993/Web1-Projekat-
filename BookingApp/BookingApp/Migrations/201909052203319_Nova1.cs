namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rezervacijas", "RezervisaniApartman", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rezervacijas", "RezervisaniApartman");
        }
    }
}
