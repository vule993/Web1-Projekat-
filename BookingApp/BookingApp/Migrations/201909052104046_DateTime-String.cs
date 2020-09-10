namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rezervacijas", "PocetniDatumRezervacije", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rezervacijas", "PocetniDatumRezervacije", c => c.DateTime(nullable: false));
        }
    }
}
