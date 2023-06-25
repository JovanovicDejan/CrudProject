namespace ProdavnicaPiva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryToDistributor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Distributors", "Country", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Distributors", "Country");
        }
    }
}
