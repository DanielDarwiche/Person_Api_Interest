namespace Person_Api_Interest.Services
{
    public interface Icrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}