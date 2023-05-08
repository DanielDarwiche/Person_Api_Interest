using Microsoft.EntityFrameworkCore;
using Person_Api_Interest.Models;

namespace Person_Api_Interest.Services
{
    public class InterestRepository : Icrud<Interest>
    {
        private AppDbContext _appDbContext;
        public InterestRepository(AppDbContext appdbcont)
        {
            this._appDbContext = appdbcont;
        }

        public async Task<Interest> Add(Interest newEntity)
        {
            if (newEntity == null) { return null; }
            var res = await _appDbContext.Interests.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var res = await _appDbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == id);

            if (res != null)
            {
                _appDbContext.Interests.Remove(res);
                await _appDbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appDbContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingel(int id)
        {
            return await _appDbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == id);
        }

        public async Task<Interest> Update(Interest entity)
        {
            var upD = await _appDbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == entity.InterestId);
            if (upD != null)
            {
                upD.InterestName = entity.InterestName;
                upD.InterestDescription = entity.InterestDescription;

                await _appDbContext.SaveChangesAsync();
                return upD;
            }
            return null;
        }
    }
}
