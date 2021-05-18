namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WCF : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agents", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "Password", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
