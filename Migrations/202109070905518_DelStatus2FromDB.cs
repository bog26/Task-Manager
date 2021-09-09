namespace Tasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelStatus2FromDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Status");
        }
        
        public override void Down()
        {
        }
    }
}
