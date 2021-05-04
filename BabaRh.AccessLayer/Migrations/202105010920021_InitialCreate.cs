namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        Password = c.String(nullable: false, maxLength: 12),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        CandidatId = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        Quizz_QuizzId = c.Int(),
                    })
                .PrimaryKey(t => t.CandidatId)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId)
                .Index(t => t.Quizz_QuizzId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        CandidatId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizzId)
                .Index(t => t.CandidatId, unique: true)
                .Index(t => t.QuestionId, unique: true);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionLib = c.String(nullable: false),
                        ModuleLib = c.String(nullable: false, maxLength: 30),
                        Niveau = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Modules", t => t.ModuleLib, cascadeDelete: true)
                .Index(t => t.ModuleLib);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ModuleLib);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        ReponseLib = c.String(nullable: false),
                        IsOk = c.Boolean(nullable: false),
                        QuestionId = c.String(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.QuestionQuizzs",
                c => new
                    {
                        Question_QuestionId = c.Int(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Quizz_QuizzId })
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Quizz_QuizzId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reponses", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionQuizzs", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "ModuleLib", "dbo.Modules");
            DropForeignKey("dbo.Candidats", "Quizz_QuizzId", "dbo.Quizzs");
            DropIndex("dbo.QuestionQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.QuestionQuizzs", new[] { "Question_QuestionId" });
            DropIndex("dbo.Reponses", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "ModuleLib" });
            DropIndex("dbo.Quizzs", new[] { "QuestionId" });
            DropIndex("dbo.Quizzs", new[] { "CandidatId" });
            DropIndex("dbo.Candidats", new[] { "Quizz_QuizzId" });
            DropTable("dbo.QuestionQuizzs");
            DropTable("dbo.Reponses");
            DropTable("dbo.Modules");
            DropTable("dbo.Questions");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Candidats");
            DropTable("dbo.Agents");
        }
    }
}
