using ImportXmlToJson.Data;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using Contract = ImportXmlToJson.Models.Contract;

namespace ImportXmlToJson.Domain
{
    public class ContractsRepository
    {
        private readonly ImportXmlToJsonContext context;

        public ContractsRepository(ImportXmlToJsonContext context)
        {
            this.context = context;
        }

        public IQueryable<Contract> GetContract()
        {
            return context.Contract.OrderBy(x => x.Shifr_Contract);
        }

        public Contract GetContractById(int? id)
        {
            return context.Contract.Single(x => x.Id == id);
        }

        public int? SaveContract(Contract entity)
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
        
        public void DeleteContract(Contract entity)
        {
            context.Contract.Remove(entity);
            context.SaveChanges();
        }
    }
}
