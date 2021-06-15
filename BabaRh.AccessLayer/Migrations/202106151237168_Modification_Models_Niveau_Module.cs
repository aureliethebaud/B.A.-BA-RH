namespace BabaRh.AccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modification_Models_Niveau_Module : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "ModuleLib", "dbo.Modules");
            DropForeignKey("dbo.QuizzModules", "ModuleLib", "dbo.Modules");
            DropIndex("dbo.Questions", new[] { "ModuleLib" });
            DropIndex("dbo.QuizzModules", new[] { "ModuleLib" });
            DropPrimaryKey("dbo.Modules");
            DropPrimaryKey("dbo.QuizzModules");
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        NiveauId = c.Int(nullable: false, identity: true),
                        NiveauLib = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.NiveauId);
            
            AddColumn("dbo.Modules", "ModuleId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Questions", "NiveauId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Module_ModuleId", c => c.Int());
            AddColumn("dbo.Quizzs", "Chrono", c => c.Int(nullable: false));
            AddColumn("dbo.QuizzModules", "Module_ModuleId", c => c.Int());
            AlterColumn("dbo.Questions", "ModuleLib", c => c.String(nullable: false));
            AlterColumn("dbo.QuizzModules", "ModuleLib", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Modules", "ModuleId");
            AddPrimaryKey("dbo.QuizzModules", new[] { "QuizzId", "ModuleLib" });
            CreateIndex("dbo.Questions", "NiveauId");
            CreateIndex("dbo.Questions", "Module_ModuleId");
            CreateIndex("dbo.QuizzModules", "Module_ModuleId");
            AddForeignKey("dbo.Questions", "NiveauId", "dbo.Niveaux", "NiveauId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Module_ModuleId", "dbo.Modules", "ModuleId");
            AddForeignKey("dbo.QuizzModules", "Module_ModuleId", "dbo.Modules", "ModuleId");
            DropColumn("dbo.Questions", "Niveau");
            DropColumn("dbo.Quizzs", "Timer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizzs", "Timer", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "Niveau", c => c.Int(nullable: false));
            DropForeignKey("dbo.QuizzModules", "Module_ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Questions", "Module_ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Questions", "NiveauId", "dbo.Niveaux");
            DropIndex("dbo.QuizzModules", new[] { "Module_ModuleId" });
            DropIndex("dbo.Questions", new[] { "Module_ModuleId" });
            DropIndex("dbo.Questions", new[] { "NiveauId" });
            DropPrimaryKey("dbo.QuizzModules");
            DropPrimaryKey("dbo.Modules");
            AlterColumn("dbo.QuizzModules", "ModuleLib", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Questions", "ModuleLib", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.QuizzModules", "Module_ModuleId");
            DropColumn("dbo.Quizzs", "Chrono");
            DropColumn("dbo.Questions", "Module_ModuleId");
            DropColumn("dbo.Questions", "NiveauId");
            DropColumn("dbo.Modules", "ModuleId");
            DropTable("dbo.Niveaux");
            AddPrimaryKey("dbo.QuizzModules", new[] { "QuizzId", "ModuleLib" });
            AddPrimaryKey("dbo.Modules", "ModuleLib");
            CreateIndex("dbo.QuizzModules", "ModuleLib");
            CreateIndex("dbo.Questions", "ModuleLib");
            AddForeignKey("dbo.QuizzModules", "ModuleLib", "dbo.Modules", "ModuleLib", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "ModuleLib", "dbo.Modules", "ModuleLib", cascadeDelete: true);
        }
    }
}
