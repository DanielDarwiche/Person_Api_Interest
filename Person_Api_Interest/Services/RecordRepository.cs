using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Person_Api_Interest.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Person_Api_Interest.Services
{
    public class RecordRepository : IRecord<Record>
    {
        private AppDbContext _appDbContext;
        public RecordRepository(AppDbContext appdbcont)
        {
            this._appDbContext = appdbcont;
        }

        //Uppgift  -  lägga in nya länkar för en person och ett intresse 
        //AddRecord  från record      

        //Uppgift  -  koppla en person till ett nytt intresse 
        //AddInterest från person(join record)       
        public async Task<Record> Add(Record newEntity)
        {

            var existingRecord = await _appDbContext.Records.FirstOrDefaultAsync(x => x.InterestId == newEntity.InterestId && x.Linkid == newEntity.Linkid && x.PersonId == newEntity.PersonId);
            if (existingRecord != null)
            {
                return null;
            }
            var uniqueRecord = await _appDbContext.Records.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return uniqueRecord.Entity;
        }

        public async Task<Record> Delete(int id)
        {
            var res = await _appDbContext.Records.FirstOrDefaultAsync(R => R.RecordId == id);

            if (res != null)
            {
                _appDbContext.Remove(res);
                await _appDbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<IEnumerable<Record>> GetAll()
        {
            return await _appDbContext.Records.ToListAsync();
        }
        public async Task<Record> GetSingel(int id)
        {

            return await _appDbContext.Records.FirstOrDefaultAsync(R => R.RecordId == id);
        }
        public async Task<Record> Update(Record recordToUpDate)
        {
            //Finding existing record in table
            var reCORD = await _appDbContext.Records.FirstOrDefaultAsync(x => x.RecordId == recordToUpDate.RecordId);

            //controlling the details are not the same for the new one as for other in table
            var existingRecord = await _appDbContext.Records.FirstOrDefaultAsync(x => x.InterestId == recordToUpDate.InterestId && x.Linkid == recordToUpDate.Linkid && x.PersonId == recordToUpDate.PersonId);
            if (existingRecord != null)
            {
                return null;
            }
            reCORD.PersonId = recordToUpDate.PersonId;
            reCORD.InterestId = recordToUpDate.InterestId;
            reCORD.Linkid = recordToUpDate.Linkid;
            await _appDbContext.SaveChangesAsync();
            return reCORD;
        }

        //Uppgift  -  hämta alla intressen för en person   
        public async Task<IEnumerable<Interest>> GetAllInterests(int id)
        {

            //finding person
            var personTS = await _appDbContext.Records.FirstOrDefaultAsync(r => r.PersonId == id);
            if (personTS != null)
            {
                //joinar interessen
                var interestsToShow = await (from i in _appDbContext.Interests
                                                 //   joinar records där intreresse id är samma 
                                             join r in _appDbContext.Records on i.InterestId equals r.InterestId
                                             //joinar personer där personid är samma som records personid
                                             join p in _appDbContext.Persons on r.PersonId equals p.PersonId
                                             // där personid är  input
                                             where p.PersonId == id
                                             //välj intressenamn
                                             select i).ToListAsync();

                return interestsToShow.Distinct();
            }
            return null;
        }
        public async Task<IEnumerable<Link>> GetAllLinks(int id)
        {
            //finding person
            var personTS = await _appDbContext.Records.FirstOrDefaultAsync(r => r.PersonId == id);
            if (personTS != null)
            {
                //joinar links
                var LinksToShow = await (from L in _appDbContext.Links
                                             //   joinar records där links id är samma 
                                         join r in _appDbContext.Records on L.LinkId equals r.Linkid
                                         //joinar personer där personid är samma som records personid
                                         join p in _appDbContext.Persons on r.PersonId equals p.PersonId
                                         // där personid är  input
                                         where p.PersonId == id
                                         //välj links
                                         select L).ToListAsync();

                return LinksToShow.Distinct();
            }
            return null;
        }
    }
}
