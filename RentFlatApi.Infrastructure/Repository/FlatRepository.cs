using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentFlatApi.Infrastructure.Context;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Infrastructure.Repository
{
    public interface IFlatRepository : IRepository<Flat>
    {
    }

    public class FlatRepository : IFlatRepository
    {
        private readonly RentContext _rentContext;

        public FlatRepository(RentContext rentContext)
        {
            _rentContext = rentContext;
        }

        public async Task<IEnumerable<Flat>> GetAll()
        {
            return await _rentContext.Flats.ToListAsync();
        }

        public async Task<Flat> GetById(long id)
        {
            return await _rentContext.Flats
                .Where(flat => flat.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task Add(Flat flat)
        {
            flat.DateOfCreation = DateTime.Now;
            await _rentContext.Flats.AddAsync(flat);
            await _rentContext.SaveChangesAsync();
        }

        public Task Update(Flat entity)
        {
            //TODO Add AutoMapper
            throw new System.NotImplementedException();
        }

        public async Task Delete(long id)
        {
            var flatToDelete = await _rentContext.Flats.SingleOrDefaultAsync(flat => flat.Id == id);
            if (flatToDelete != null)
            {
                _rentContext.Flats.Remove(flatToDelete);
                await _rentContext.SaveChangesAsync();
            }
        }
    }
}