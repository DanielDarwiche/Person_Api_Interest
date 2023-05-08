using Microsoft.AspNetCore.Mvc;
using Person_Api_Interest.Models;

namespace Person_Api_Interest.Services
{
    public interface IRecord<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<IEnumerable<Interest>> GetAllInterests(int id);
        Task<IEnumerable<Link>> GetAllLinks(int id);
    }
}
