namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UlicaBroj = c.String(),
                        NaseljenoMesto = c.String(),
                        PostanskiBroj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Apartmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        TipApartmana = c.String(),
                        BrojSoba = c.Int(nullable: false),
                        BrojGostiju = c.Int(nullable: false),
                        CenaPoNoci = c.Double(nullable: false),
                        Ocena = c.Double(nullable: false),
                        VremeZaPrijavu = c.String(),
                        VremeZaOdjavu = c.String(),
                        Status = c.Boolean(nullable: false),
                        Korisnik_Id = c.Int(),
                        Korisnik_Id1 = c.Int(),
                        Domacin_Id = c.Int(),
                        Lokacija_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_Id)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_Id1)
                .ForeignKey("dbo.Korisniks", t => t.Domacin_Id)
                .ForeignKey("dbo.Lokacijas", t => t.Lokacija_Id)
                .Index(t => t.Korisnik_Id)
                .Index(t => t.Korisnik_Id1)
                .Index(t => t.Domacin_Id)
                .Index(t => t.Lokacija_Id);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Pol = c.String(),
                        Uloga = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rezervacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PocetniDatumRezervacije = c.DateTime(nullable: false),
                        BrojNocenja = c.Int(nullable: false),
                        UkupnaCena = c.Double(nullable: false),
                        Status = c.String(),
                        Gost_Id = c.Int(),
                        RezervisaniApartman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Gost_Id)
                .ForeignKey("dbo.Apartmen", t => t.RezervisaniApartman_Id)
                .Index(t => t.Gost_Id)
                .Index(t => t.RezervisaniApartman_Id);
            
            CreateTable(
                "dbo.Komentars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TekstKomentara = c.String(),
                        Ocena = c.Double(nullable: false),
                        Status = c.String(),
                        Korisnik_Id = c.Int(),
                        Apartman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_Id)
                .ForeignKey("dbo.Apartmen", t => t.Apartman_Id)
                .Index(t => t.Korisnik_Id)
                .Index(t => t.Apartman_Id);
            
            CreateTable(
                "dbo.SadrzajApartmanas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Apartman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartmen", t => t.Apartman_Id)
                .Index(t => t.Apartman_Id);
            
            CreateTable(
                "dbo.Lokacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeografskaSirina = c.String(),
                        GeografskaDuzina = c.String(),
                        Adresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresas", t => t.Adresa_Id)
                .Index(t => t.Adresa_Id);
            
            CreateTable(
                "dbo.Slikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Name = c.String(),
                        Apartman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartmen", t => t.Apartman_Id)
                .Index(t => t.Apartman_Id);
            
            CreateTable(
                "dbo.DostupniSadrzajis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slikas", "Apartman_Id", "dbo.Apartmen");
            DropForeignKey("dbo.Apartmen", "Lokacija_Id", "dbo.Lokacijas");
            DropForeignKey("dbo.Lokacijas", "Adresa_Id", "dbo.Adresas");
            DropForeignKey("dbo.SadrzajApartmanas", "Apartman_Id", "dbo.Apartmen");
            DropForeignKey("dbo.Komentars", "Apartman_Id", "dbo.Apartmen");
            DropForeignKey("dbo.Komentars", "Korisnik_Id", "dbo.Korisniks");
            DropForeignKey("dbo.Apartmen", "Domacin_Id", "dbo.Korisniks");
            DropForeignKey("dbo.Rezervacijas", "RezervisaniApartman_Id", "dbo.Apartmen");
            DropForeignKey("dbo.Rezervacijas", "Gost_Id", "dbo.Korisniks");
            DropForeignKey("dbo.Apartmen", "Korisnik_Id1", "dbo.Korisniks");
            DropForeignKey("dbo.Apartmen", "Korisnik_Id", "dbo.Korisniks");
            DropIndex("dbo.Slikas", new[] { "Apartman_Id" });
            DropIndex("dbo.Lokacijas", new[] { "Adresa_Id" });
            DropIndex("dbo.SadrzajApartmanas", new[] { "Apartman_Id" });
            DropIndex("dbo.Komentars", new[] { "Apartman_Id" });
            DropIndex("dbo.Komentars", new[] { "Korisnik_Id" });
            DropIndex("dbo.Rezervacijas", new[] { "RezervisaniApartman_Id" });
            DropIndex("dbo.Rezervacijas", new[] { "Gost_Id" });
            DropIndex("dbo.Apartmen", new[] { "Lokacija_Id" });
            DropIndex("dbo.Apartmen", new[] { "Domacin_Id" });
            DropIndex("dbo.Apartmen", new[] { "Korisnik_Id1" });
            DropIndex("dbo.Apartmen", new[] { "Korisnik_Id" });
            DropTable("dbo.DostupniSadrzajis");
            DropTable("dbo.Slikas");
            DropTable("dbo.Lokacijas");
            DropTable("dbo.SadrzajApartmanas");
            DropTable("dbo.Komentars");
            DropTable("dbo.Rezervacijas");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Apartmen");
            DropTable("dbo.Adresas");
        }
    }
}
