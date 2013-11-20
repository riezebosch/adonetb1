namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OmschrijvingMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Omschrijving", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Omschrijving", c => c.String());
        }
    }
}
