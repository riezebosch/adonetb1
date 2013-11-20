namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Omschrijving2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Products", "Omschrijving", "Omschrijving2");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Products", "Omschrijving2", "Omschrijving");
        }
    }
}
