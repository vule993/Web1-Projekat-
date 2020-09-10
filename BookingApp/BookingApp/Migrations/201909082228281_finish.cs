namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finish : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prazniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dan = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prazniks");
        }
    }
}
