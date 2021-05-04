using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new BabaRhDbContext())
            {
                if (db.Database.Exists())
                {
                    Console.WriteLine("Suppression de la base de données");
                    db.Database.Delete();
                }

                Console.WriteLine("Création de la base de données");
                db.Database.Create();
            }
        }
    }
}
