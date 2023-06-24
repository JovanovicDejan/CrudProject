namespace ProdavnicaPiva.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedDistributor : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Distributors (Name) VALUES ('Carlsberg')");
            Sql("INSERT INTO Distributors (Name) VALUES ('Heineken N.V')");
            Sql("INSERT INTO Distributors (Name) VALUES ('Local distribution')");
        }

        public override void Down()
        {
        }
    }
}
