namespace Tasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelStatus1FromDB : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropTable("dbo.Status");
        }
    }
}
