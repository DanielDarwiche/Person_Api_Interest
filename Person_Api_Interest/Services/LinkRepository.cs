using Microsoft.EntityFrameworkCore;
using Person_Api_Interest.Models;

namespace Person_Api_Interest.Services
{
    public class LinkRepository : Icrud<Link>
    {
        private AppDbContext _appDbContext;
        public LinkRepository(AppDbContext appdbcont)
        {
            this._appDbContext = appdbcont;
        }


        public async Task<Link> Add(Link newEntity)
        {
            var res = await _appDbContext.Links.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return res.Entity;
            ////Alternative code format
            //await _appDbContext.Links.AddAsync(newEntity);
            //await _appDbContext.SaveChangesAsync();
            //return (Link)_appDbContext.Links.Where(L=>L.LinkId==newEntity.LinkId);
        }
        public async Task<Link> Delete(int id)
        {
            var res = await _appDbContext.Links.FirstOrDefaultAsync(L => L.LinkId == id);
            if (res != null)
            {
                _appDbContext.Links.Remove(res);
                await _appDbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }
        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appDbContext.Links.ToListAsync();
        }
        public async Task<Link> GetSingel(int id)
        {
            return await _appDbContext.Links.FirstOrDefaultAsync(L => L.LinkId == id);
        }
        public async Task<Link> Update(Link entity)
        {
            var upD = await _appDbContext.Links.FirstOrDefaultAsync(L => L.LinkId == entity.LinkId);
            if (upD != null)
            {
                upD.LinkURL = entity.LinkURL;
                await _appDbContext.SaveChangesAsync();
                return upD;
            }
            return null;
        }
    }
}
