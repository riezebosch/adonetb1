namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailRequired : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Persoons SET Email = 'unknown@unknown.com' WHERE Email IS NULL");
            AlterColumn("dbo.Persoons", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persoons", "Email", c => c.String(maxLength: 50));
        }
    }
}
