using Microsoft.EntityFrameworkCore;
using Person_Api_Interest.Models;

namespace Person_Api_Interest.Services
{
    public class PersonRepository : Icrud<Person>
    {
        private AppDbContext _appDbContext;
        public PersonRepository(AppDbContext appdbcont)
        {
            this._appDbContext = appdbcont;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var res = await _appDbContext.Persons.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<Person> Delete(int id)
        {
            var res = await _appDbContext.Persons.FirstOrDefaultAsync(per => per.PersonId == id);
            if (res != null)
            {
                _appDbContext.Persons.Remove(res);
                await _appDbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }
        //Uppgift  -  Hämta alla personer           
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appDbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetSingel(int id)
        {
            return await _appDbContext.Persons.FirstOrDefaultAsync(per => per.PersonId == id);
        }
        public async Task<Person> Update(Person entity)
        {
            var upD = await _appDbContext.Persons.FirstOrDefaultAsync(per => per.PersonId == entity.PersonId);
            if (upD != null)
            {
                upD.FirstName = entity.FirstName;
                upD.LastName = entity.LastName;
                upD.Phone = entity.Phone;
                upD.Age = entity.Age;

                await _appDbContext.SaveChangesAsync();
                return upD;
            }
            return null;
        }
    }
}
