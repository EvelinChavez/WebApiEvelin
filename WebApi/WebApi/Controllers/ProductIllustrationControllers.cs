using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Interface;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductIllustrationController : ControllerBase
    {
        private readonly IProductIllustrationRepository _repository;

        public ProductIllustrationController(IProductIllustrationRepository repository)
        {
            _repository = repository;
        }

        // Obtener todas las ilustraciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductIllustration>>> GetProductIllustrations()
        {
            var illustrations = await _repository.GetIllustrationsAsync(); // Cambié el método a GetIllustrationsAsync
            return Ok(illustrations);
        }

        // Obtener una ilustración por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductIllustration>> GetProductIllustration(int id)
        {
            var illustration = await _repository.GetIllustrationByIdAsync(id); // Cambié el método a GetIllustrationByIdAsync
            if (illustration == null)
            {
                return NotFound();
            }
            return Ok(illustration);
        }

        // Crear una nueva ilustración
        [HttpPost]
        public async Task<ActionResult<ProductIllustration>> PostProductIllustration(ProductIllustration illustration)
        {
            var createdIllustration = await _repository.CreateIllustrationAsync(illustration); // Cambié el método a CreateIllustrationAsync
            return CreatedAtAction(nameof(GetProductIllustration), new { id = createdIllustration.IllustrationID }, createdIllustration);
        }

        // Actualizar una ilustración existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductIllustration(int id, ProductIllustration illustration)
        {
            if (id != illustration.IllustrationID)
            {
                return BadRequest();
            }

            var updated = await _repository.UpdateIllustrationAsync(id, illustration); // Cambié el método a UpdateIllustrationAsync
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Eliminar una ilustración
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductIllustration(int id)
        {
            var deleted = await _repository.DeleteIllustrationAsync(id); // Cambié el método a DeleteIllustrationAsync
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
