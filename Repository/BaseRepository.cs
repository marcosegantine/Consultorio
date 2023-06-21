using ProjectDoctor.Context;
using ProjectDoctor.Repository.Interfaces;
using System.Threading.Tasks;

namespace ProjectDoctor.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ProjectDoctorContext _context;

        public BaseRepository(ProjectDoctorContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
