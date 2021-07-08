using MongoDB.Driver;
using Payment.Charges.Domain.Contracts;
using Payment.Charges.Domain.Contracts.Mongo;
using Payment.Charges.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Infrastructure
{
    public class ChargeRepository : Repository<Charge>, IChargesRepository
    {
        public ChargeRepository(IMongoContext context) : base(context)
        {
        }
        public virtual async ValueTask<Charge> SearchbyMonthAndCPF(int month,string cpf)
        {
            var filter = Builders<Charge>.Filter.Where(x=>x.DueDate.Date.Month ==month && x.CPF == cpf);
            var filter_result = base.Context.GetCollection<Charge>("Chargedb").Find(filter).FirstOrDefault();

            return filter_result;
        }
        public virtual async ValueTask<Charge> SearchbyMonth(int month)
        {
            var filter = Builders<Charge>.Filter.Eq(x => x.DueDate.Date.Month, month);
            var filter_result = base.Context.GetCollection<Charge>("Chargedb").Find(filter).FirstOrDefault();

            return filter_result;
        }
        public virtual async ValueTask<Charge> SearchCPF(string cpf)
        {
            var filter = Builders<Charge>.Filter.Where(x => x.CPF.Equals(cpf));
            var filter_result = base.Context.GetCollection<Charge>("Chargedb").Find(filter).FirstOrDefault();

            return filter_result;
        }
        public virtual async Task<IEnumerable<Charge>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<Charge>.Filter.Empty);
            return all.ToList();
        }
    }
}
