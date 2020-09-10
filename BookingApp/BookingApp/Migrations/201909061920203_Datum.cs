namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dan = c.DateTime(nullable: false),
                        Apartman_Id = c.Int(),
                        Apartman_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartmen", t => t.Apartman_Id)
                .ForeignKey("dbo.Apartmen", t => t.Apartman_Id1)
                .Index(t => t.Apartman_Id)
                .Index(t => t.Apartman_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Data", "Apartman_Id1", "dbo.Apartmen");
            DropForeignKey("dbo.Data", "Apartman_Id", "dbo.Apartmen");
            DropIndex("dbo.Data", new[] { "Apartman_Id1" });
            DropIndex("dbo.Data", new[] { "Apartman_Id" });
            DropTable("dbo.Data");
        }
    }
}
