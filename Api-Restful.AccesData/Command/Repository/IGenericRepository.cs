

namespace Api_Restful.AccesData.Command.Repository
{
    public interface IGenericRepository
    {
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T>(int id) where T : class;
    }
}
