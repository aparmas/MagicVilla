using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repositories.IRepositories;

namespace MagicVilla_API.Repositories
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly MagicVillaDBContext _dbContext;

        public VillaRepository(MagicVillaDBContext dBContext): base(dBContext)
        {
            _dbContext = dBContext;
            
        }

        public async Task<Villa> UpdateVilla(Villa villa)
        {
            _dbContext.Update(villa);
            await _dbContext.SaveChangesAsync();
            return villa;
        }
    }
}
