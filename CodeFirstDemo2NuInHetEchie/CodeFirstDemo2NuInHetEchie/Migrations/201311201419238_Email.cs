namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persoons", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persoons", "Email");
        }
    }
}
