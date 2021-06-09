namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agents", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
