namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "Status");
        }
    }
}
