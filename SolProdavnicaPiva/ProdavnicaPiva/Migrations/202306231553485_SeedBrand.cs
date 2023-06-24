namespace ProdavnicaPiva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedBrand : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Brands (Name) VALUES ('Jelen')");
            Sql("INSERT INTO Brands (Name) VALUES ('Niksicko')");
            Sql("INSERT INTO Brands (Name) VALUES ('Zajecarsko')");
            Sql("INSERT INTO Brands (Name) VALUES ('Lav')");
        }

        public override void Down()
        {
        }
    }
}
