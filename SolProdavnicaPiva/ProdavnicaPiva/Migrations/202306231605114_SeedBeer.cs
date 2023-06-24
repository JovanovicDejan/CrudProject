namespace ProdavnicaPiva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedBeer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Beers (BrandId, DistributorId, ManufacturerId) VALUES (1,1,1)");
            Sql("INSERT INTO Beers (BrandId, DistributorId, ManufacturerId) VALUES (2,3,2)");
            Sql("INSERT INTO Beers (BrandId, DistributorId, ManufacturerId) VALUES (3,3,3)");
        }

        public override void Down()
        {
        }
    }
}
