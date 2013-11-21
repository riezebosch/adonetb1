namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pluralization : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Persoons", newName: "Persoon");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.ProductPersoons", newName: "ProductPersoon");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductPersoon", newName: "ProductPersoons");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Persoon", newName: "Persoons");
        }
    }
}
