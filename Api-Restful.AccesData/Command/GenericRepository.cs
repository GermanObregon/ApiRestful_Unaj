using Api_Restful.AccesData.Command.Repository;


namespace Api_Restful.AccesData.Command
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(int id) where T : class
        {
            _context.Remove(_context.Find<T>(id));
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
