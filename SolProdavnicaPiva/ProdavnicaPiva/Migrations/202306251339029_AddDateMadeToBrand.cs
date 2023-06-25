namespace ProdavnicaPiva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateMadeToBrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "DateMade", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "DateMade");
        }
    }
}
