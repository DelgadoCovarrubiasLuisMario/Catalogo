using Catalogo.Modelos;

namespace Catalogo.Repositorio
{
    public interface IRepositorioClasificaciones
    {
        Task<List<Clasificacion>> GetClasificaciones();
        Task<Clasificacion> GetClasificacion(int id);
        Task<Clasificacion?> Get(int id);
        Task<Clasificacion> Add(Clasificacion clasificacion);
        Task Update(int id, Clasificacion clasificacion);
        Task Delete(int id);
    }
}
