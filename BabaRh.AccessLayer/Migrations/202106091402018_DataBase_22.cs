namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizzModules",
                c => new
                    {
                        Quizz_QuizzId = c.Int(nullable: false),
                        Module_ModuleLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => new { t.Quizz_QuizzId, t.Module_ModuleLib })
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.Module_ModuleLib, cascadeDelete: true)
                .Index(t => t.Quizz_QuizzId)
                .Index(t => t.Module_ModuleLib);
            
            AddColumn("dbo.Quizzs", "Timer", c => c.DateTime(nullable: false));
            AddColumn("dbo.Quizzs", "NbQuestion", c => c.Int(nullable: false));
            AddColumn("dbo.Quizzs", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizzModules", "Module_ModuleLib", "dbo.Modules");
            DropForeignKey("dbo.QuizzModules", "Quizz_QuizzId", "dbo.Quizzs");
            DropIndex("dbo.QuizzModules", new[] { "Module_ModuleLib" });
            DropIndex("dbo.QuizzModules", new[] { "Quizz_QuizzId" });
            DropColumn("dbo.Quizzs", "Url");
            DropColumn("dbo.Quizzs", "NbQuestion");
            DropColumn("dbo.Quizzs", "Timer");
            DropTable("dbo.QuizzModules");
        }
    }
}
