using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RentFlatApi.Contract.FlatDto;
using RentFlatApi.Infrastructure.Model;
using RentFlatApi.Infrastructure.Repository;

namespace RentFlatApi.Core.Services
{
    public interface IFlatService : IService<FlatDto>
    {
    }

    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _iFlatRepository;
        private readonly IMapper _mapper;

        public FlatService(IFlatRepository iFlatRepository, IMapper mapper)
        {
            _iFlatRepository = iFlatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlatDto>> GetAll()
        {
            var flats = await _iFlatRepository.GetAll();
            return _mapper.Map<List<FlatDto>>(flats);
        }

        public async Task<FlatDto> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Add(FlatDto flat)
        {
            await _iFlatRepository.Add(_mapper.Map<Flat>(flat));
        }

        public async Task Update(FlatDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}