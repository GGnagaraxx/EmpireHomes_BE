namespace EmpireHomes_BE.Repository
{
    public interface IRepoBase< T > : IDisposable
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id );
        void Add( T item );
        void Update(T item );
        void Delete(int id);
        void Save();


    }
}
