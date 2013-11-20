namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persoons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Geboortedatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductPersoons",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Persoon_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Persoon_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Persoons", t => t.Persoon_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Persoon_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPersoons", "Persoon_Id", "dbo.Persoons");
            DropForeignKey("dbo.ProductPersoons", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductPersoons", new[] { "Persoon_Id" });
            DropIndex("dbo.ProductPersoons", new[] { "Product_Id" });
            DropTable("dbo.ProductPersoons");
            DropTable("dbo.Products");
            DropTable("dbo.Persoons");
        }
    }
}
