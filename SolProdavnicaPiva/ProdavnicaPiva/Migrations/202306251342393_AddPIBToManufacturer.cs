namespace ProdavnicaPiva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPIBToManufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturers", "PIB", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacturers", "PIB");
        }
    }
}
