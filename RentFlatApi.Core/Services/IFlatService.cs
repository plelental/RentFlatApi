using System.Collections.Generic;
using System.Threading.Tasks;
using RentFlatApi.Infrastructure.Model;
using RentFlatApi.Infrastructure.Repository;

namespace RentFlatApi.Core.Services
{
    public class IFlatService : IService<Flat>
    {
        private readonly IFlatRepository _flatRepository;

        public IFlatService(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository;
        }

        public Task<IEnumerable<Flat>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Flat> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(Flat flat)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Flat entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}