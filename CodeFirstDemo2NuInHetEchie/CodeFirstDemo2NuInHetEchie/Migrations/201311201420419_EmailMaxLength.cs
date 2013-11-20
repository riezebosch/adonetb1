namespace CodeFirstDemo2NuInHetEchie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persoons", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persoons", "Email", c => c.String());
        }
    }
}
