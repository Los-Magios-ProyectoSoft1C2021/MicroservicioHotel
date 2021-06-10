using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Commands
{
    public interface IGenericsRepository
    {
        Task Add<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Remove<T>(T entity) where T : class;
    }
}
