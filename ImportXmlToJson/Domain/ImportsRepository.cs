using ImportXmlToJson.Data;
using Microsoft.EntityFrameworkCore;
using Imports = ImportXmlToJson.Models.Imports;

namespace ImportXmlToJson.Domain
{ 

    public class ImportsRepository
    {
        private readonly ImportXmlToJsonContext context;

        public ImportsRepository(ImportXmlToJsonContext context)
        {
            this.context = context;
        }

        public IQueryable<Imports> GetImports()
        {
            return context.Imports.OrderBy(x => x.Contract_Stage);
        }

        public Imports GetImportsById(int? id)
        {
            return context.Imports.Single(x => x.Id == id);
        }

        public Imports GetImportsByStage(string stage)
        {
            return context.Imports.Single(x => x.Contract_Stage == stage);
        }

        public int? SaveImports(Imports entity)
        {
            if (entity.Id == null)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();

            return entity.Id;
        }


    }
}
