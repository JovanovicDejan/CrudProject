namespace ProdavnicaPiva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedManufacturer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Apatinska pivara')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Trebjesa')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Heinkien Srbija')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('Krugher&Brent')");
            Sql("INSERT INTO Manufacturers (Name) VALUES ('BIP')");
        }

        public override void Down()
        {
        }
    }
}
