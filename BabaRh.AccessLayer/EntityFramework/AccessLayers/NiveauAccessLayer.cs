namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    using BabaRh.AccessLayer.EntityFramework.Interfaces;
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NiveauAccessLayer : INiveauAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static NiveauAccessLayer instance;
        public static NiveauAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new NiveauAccessLayer();

                return instance;
            }

        }
        private NiveauAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }


        public async Task<int> AddAsync(Niveau niveau)
        {
            this.context.Niveaux.Add(niveau);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return niveau.NiveauId;
        }

        public async Task<bool> DeleteAsync(int niveauId)
        {
            var niveauToDelete = this.Get(niveauId);
            if (niveauToDelete != null)
            {
                this.context.Niveaux.Remove(niveauToDelete);
                this.context.SaveChanges();

                var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

                return result > 0;
            }
            else
            {
                return false;
            }
        }


        public Niveau Get(int niveauId)
        {
            return this.context.Niveaux.AsQueryable().SingleOrDefault(x => x.NiveauId == niveauId);
        }


        public List<Niveau> GetAll()
        {
            return this.context.Niveaux.AsQueryable().ToList();
        }

        public async Task<bool> UpdateAsync(Niveau niveau)
        {
            var niveauToUpdate = this.context.Niveaux.FirstOrDefault(n => n.NiveauId == niveau.NiveauId);

            if (niveau == null)
                return false;

            niveauToUpdate.NiveauLib = niveau.NiveauLib;


            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }


    }
}
