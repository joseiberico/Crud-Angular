using Api_Mascotas.Context;
using Api_Mascotas.Models;
using Api_Mascotas.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_Mascotas.Repository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly DbSet<Mascota> _dbset;
        private readonly MascotasBdContext _context;

        public MascotaRepository(MascotasBdContext context)
        {
            _dbset = context.Set<Mascota>();
            _context = context;
        }

        public async Task<Mascota> Create(Mascota entity)
        {
            Mascota mascota = new Mascota()
            {
                Nombre = entity.Nombre,
                Edad = entity.Edad,
                Descripcion = entity.Descripcion
            };

            EntityEntry<Mascota> result = await _context.Mascota.AddAsync(mascota);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Mascota entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Mascota>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Mascota> GetById(int id)
        {
            return await _dbset.FirstAsync(x => x.IdMascota == id);
        }

        public async Task<bool> Update(Mascota entity)
        {
            try
            {
                _context.Mascota.Update(entity);
                await _context.SaveChangesAsync();
                return true; // La actualización fue exitosa
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre
                return false; // La actualización falló
            }
        }

    }
}
