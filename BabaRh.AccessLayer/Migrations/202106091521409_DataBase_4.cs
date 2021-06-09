namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Quizzs", "CandidatId");
            AddForeignKey("dbo.Quizzs", "CandidatId", "dbo.Candidats", "CandidatId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizzs", "CandidatId", "dbo.Candidats");
            DropIndex("dbo.Quizzs", new[] { "CandidatId" });
        }
    }
}
