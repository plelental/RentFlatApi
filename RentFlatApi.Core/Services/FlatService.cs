using System.Collections.Generic;
using System.Threading.Tasks;
using RentFlatApi.Contract.FlatDto;
namespace RentFlatApi.Core.Services
{
    public interface IFlatService : IService<FlatDto>
    {
          
    }

    public class FlatService : IFlatService
    {
        public Task<IEnumerable<FlatDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<FlatDto> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task Add(FlatDto flat)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(FlatDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}