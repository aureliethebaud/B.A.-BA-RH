namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        CandidatId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CandidatId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ModuleLib);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionLib = c.String(nullable: false),
                        ModuleLib = c.String(nullable: false, maxLength: 30),
                        Niveau = c.Int(nullable: false),
                        QuestionOuverte = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Modules", t => t.ModuleLib, cascadeDelete: true)
                .Index(t => t.ModuleLib);
            
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.QuestionId })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        CandidatId = c.Int(nullable: false),
                        Timer = c.DateTime(nullable: false),
                        NbQuestion = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Candidats", t => t.CandidatId, cascadeDelete: true)
                .Index(t => t.CandidatId);
            
            CreateTable(
                "dbo.QuizzModules",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        ModuleLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.ModuleLib })
                .ForeignKey("dbo.Modules", t => t.ModuleLib, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId)
                .Index(t => t.ModuleLib);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        ReponseLib = c.String(nullable: false),
                        IsOk = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuizzModules", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuizzModules", "ModuleLib", "dbo.Modules");
            DropForeignKey("dbo.Quizzs", "CandidatId", "dbo.Candidats");
            DropForeignKey("dbo.QuizzQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "ModuleLib", "dbo.Modules");
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropIndex("dbo.QuizzModules", new[] { "ModuleLib" });
            DropIndex("dbo.QuizzModules", new[] { "QuizzId" });
            DropIndex("dbo.Quizzs", new[] { "CandidatId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuestionId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuizzId" });
            DropIndex("dbo.Questions", new[] { "ModuleLib" });
            DropTable("dbo.Reponses");
            DropTable("dbo.QuizzModules");
            DropTable("dbo.Quizzs");
            DropTable("dbo.QuizzQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.Modules");
            DropTable("dbo.Candidats");
            DropTable("dbo.Agents");
        }
    }
}
