﻿namespace Tasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatus1ToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
