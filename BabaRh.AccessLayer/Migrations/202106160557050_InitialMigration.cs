namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionLib = c.String(nullable: false),
                        QuestionOuverte = c.Boolean(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        NiveauId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Niveaux", t => t.NiveauId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.NiveauId);
            
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        NiveauId = c.Int(nullable: false, identity: true),
                        NiveauLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.NiveauId);
            
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
                        Chrono = c.Int(nullable: false),
                        NbQuestion = c.Int(nullable: false),
                        Url = c.String(),
                        CandidatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizzId)
                .ForeignKey("dbo.Candidats", t => t.CandidatId, cascadeDelete: true)
                .Index(t => t.CandidatId);
            
            CreateTable(
                "dbo.QuizzModules",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.ModuleId })
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId)
                .Index(t => t.ModuleId);
            
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
            DropForeignKey("dbo.QuizzModules", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Quizzs", "CandidatId", "dbo.Candidats");
            DropForeignKey("dbo.QuizzQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "NiveauId", "dbo.Niveaux");
            DropForeignKey("dbo.Questions", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Reponses", new[] { "QuestionId" });
            DropIndex("dbo.QuizzModules", new[] { "ModuleId" });
            DropIndex("dbo.QuizzModules", new[] { "QuizzId" });
            DropIndex("dbo.Quizzs", new[] { "CandidatId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuestionId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuizzId" });
            DropIndex("dbo.Questions", new[] { "NiveauId" });
            DropIndex("dbo.Questions", new[] { "ModuleId" });
            DropTable("dbo.Reponses");
            DropTable("dbo.QuizzModules");
            DropTable("dbo.Quizzs");
            DropTable("dbo.QuizzQuestions");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Questions");
            DropTable("dbo.Modules");
            DropTable("dbo.Candidats");
            DropTable("dbo.Agents");
        }
    }
}
