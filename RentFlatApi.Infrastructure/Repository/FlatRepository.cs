using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            var flats = await _rentContext.Flat.ToListAsync();
            flats.ForEach(x => { _rentContext.Entry(x).Reference(y => y.Address).LoadAsync(); });
            return flats;
        }

        public async Task<Flat> GetById(long id)
        {
            return await _rentContext.Flat
                .Where(flat => flat.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task Add(Flat flat)
        {
            flat.DateOfCreation = DateTime.Now;
            await _rentContext.Flat
                .Include(x => x.Address)
                .Include(x => x.Owner)
                .Include(x => x.Tenant)
                .Include(x => x.Images)
                .FirstAsync();
            await _rentContext.Flat.AddAsync(flat);
            await _rentContext.SaveChangesAsync();
        }

        public Task Update(Flat entity)
        {
            //TODO Add AutoMapper
            throw new System.NotImplementedException();
        }

        public async Task Delete(long id)
        {
            var flatToDelete = await _rentContext.Flat.SingleOrDefaultAsync(flat => flat.Id == id);
            if (flatToDelete != null)
            {
                _rentContext.Flat.Remove(flatToDelete);
                await _rentContext.SaveChangesAsync();
            }
        }
    }
}