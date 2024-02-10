namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Mobile", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Mobile", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
