using System.Threading.Tasks;

namespace CoolestMovieAPI.Services
{
    public interface IBaseRepository
    {

        // Genereic methods
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> Save();


    }
}
