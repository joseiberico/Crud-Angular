using Api_Mascotas.Models;

namespace Api_Mascotas.Repository.iRepository
{
    public interface IMascotaRepository
    {
        Task<Mascota> GetById(int id);
        Task<IEnumerable<Mascota>> GetAll();
        Task<Mascota> Create(Mascota entity);
        Task<bool> Update(Mascota entity);
        Task<bool> Delete (int id);

    }
}
