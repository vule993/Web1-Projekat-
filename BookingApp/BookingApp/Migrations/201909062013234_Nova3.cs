namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data", "Dan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Data", "Dan", c => c.DateTime(nullable: false));
        }
    }
}
