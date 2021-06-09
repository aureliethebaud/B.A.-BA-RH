namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase_2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionQuizzs", newName: "QuizzQuestions");
            DropForeignKey("dbo.Candidats", "Quizz_QuizzId", "dbo.Quizzs");
            DropIndex("dbo.Candidats", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.Quizzs", new[] { "CandidatId" });
            DropIndex("dbo.Quizzs", new[] { "QuestionId" });
            DropPrimaryKey("dbo.QuizzQuestions");
            AddColumn("dbo.Questions", "QuestionOuverte", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.QuizzQuestions", new[] { "Quizz_QuizzId", "Question_QuestionId" });
            DropColumn("dbo.Candidats", "Quizz_QuizzId");
            DropColumn("dbo.Quizzs", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizzs", "QuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.Candidats", "Quizz_QuizzId", c => c.Int());
            DropPrimaryKey("dbo.QuizzQuestions");
            DropColumn("dbo.Questions", "QuestionOuverte");
            AddPrimaryKey("dbo.QuizzQuestions", new[] { "Question_QuestionId", "Quizz_QuizzId" });
            CreateIndex("dbo.Quizzs", "QuestionId", unique: true);
            CreateIndex("dbo.Quizzs", "CandidatId", unique: true);
            CreateIndex("dbo.Candidats", "Quizz_QuizzId");
            AddForeignKey("dbo.Candidats", "Quizz_QuizzId", "dbo.Quizzs", "QuizzId");
            RenameTable(name: "dbo.QuizzQuestions", newName: "QuestionQuizzs");
        }
    }
}
