using Api_Mascotas.Models;
using Api_Mascotas.Repository.iRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api_Mascotas.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MascotaController : Controller
    {
        private readonly IMascotaRepository _repository;

        public MascotaController(IMascotaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mascota = await _repository.GetAll();
            return Ok(mascota);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var mascota = await _repository.GetById(id);
            return Ok(mascota);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Mascota mascota)
        {
            Mascota result = await _repository.Create(mascota);
            return new CreatedResult($"https://localhost:7237/api/Mascota/{result.IdMascota}", null);

        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] Mascota mascota)
        {
            Mascota existingMascota = await _repository.GetById(id);

            if (existingMascota == null)
            {
                return new NotFoundResult(); // Devuelve un código de estado 404 si la mascota no se encuentra
            }

            // Actualiza las propiedades de existingMascota con los valores de mascota
            existingMascota.Nombre = mascota.Nombre;
            existingMascota.Edad = mascota.Edad;
            existingMascota.Descripcion = mascota.Descripcion;

            bool result = await _repository.Update(existingMascota);

            if (result)
            {
                return new OkObjectResult(true); // Devuelve true para indicar que la actualización fue exitosa
            }
            else
            {
                // Manejar el error si la actualización falla
                return new NotFoundResult(); // Devuelve un código de estado 500 en caso de error interno
            }
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return new OkObjectResult(result);
        }

        
    }
}
