using BabaRh.AccessLayer.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace BabaRh.AccessLayer.EntityFramework
{
    public class BabaRhDataBaseContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « BabaRhDataBaseContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « BabaRh.AccessLayer.EntityFramework.BabaRhDataBaseContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « BabaRhDataBaseContext » dans le fichier de configuration de l'application.
        public BabaRhDataBaseContext()
            : base("name=BabaRhDataBaseContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Candidat> Candidats { get; set; }
        public virtual DbSet<Quizz> Quizzs { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reponse> Reponses { get; set; }
        public virtual DbSet<QuizzModule> QuizzModules { get; set; }
        public virtual DbSet<Niveau> Niveaux { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}