using Catalogo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositorio
{
    public class RepositorioClasificaciones : IRepositorioClasificaciones
    {
        private readonly CatalogoDBContext _context;

        public RepositorioClasificaciones(CatalogoDBContext context)
        {
            _context = context;
        }
        public async Task<Clasificacion> Add(Clasificacion clasificacion)
        {
            await _context.Clasificaciones.AddAsync(clasificacion);
            await _context.SaveChangesAsync();
            return clasificacion;
        }

        public async Task Delete(int id)
        {
            var clasificacion = await _context.Clasificaciones.FindAsync(id);
            if (clasificacion != null)
            {
                _context.Clasificaciones.Remove(clasificacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Clasificacion?> Get(int id)
        {
            return await _context.Clasificaciones.FindAsync(id);
        }

        public async Task<Clasificacion> GetClasificacion(int id)
        {
            return await _context.Clasificaciones.Include(r => r.Personas).FirstAsync(c => c.Id == id);
        }

        public async Task<List<Clasificacion>> GetClasificaciones()
        {
            return await _context.Clasificaciones.ToListAsync();
        }

        public async Task Update(int id, Clasificacion clasificacion)
        {
            var clasificacionactual = await _context.Clasificaciones.FindAsync(id);
            if (clasificacionactual != null)
            {
                clasificacionactual.Name = clasificacion.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}

