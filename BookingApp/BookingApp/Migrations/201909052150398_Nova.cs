namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nova : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rezervacijas", name: "RezervisaniApartman_Id", newName: "Apartman_Id");
            RenameIndex(table: "dbo.Rezervacijas", name: "IX_RezervisaniApartman_Id", newName: "IX_Apartman_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rezervacijas", name: "IX_Apartman_Id", newName: "IX_RezervisaniApartman_Id");
            RenameColumn(table: "dbo.Rezervacijas", name: "Apartman_Id", newName: "RezervisaniApartman_Id");
        }
    }
}
