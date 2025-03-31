using Microsoft.EntityFrameworkCore;
using WebApi.Interface;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class ProductIllustrationRepository : IProductIllustrationRepository
    {
        private readonly AppDbContext _context;

        public ProductIllustrationRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las ilustraciones
        public async Task<IEnumerable<ProductIllustration>> GetIllustrationsAsync()
        {
            return await _context.ProductIlustrations.AsNoTracking().ToListAsync(); // Asegúrate de usar AsNoTracking() para mejorar la consulta
        }

        // Obtener una ilustración por ID
        public async Task<ProductIllustration?> GetIllustrationByIdAsync(int illustrationId)
        {
            return await _context.ProductIlustrations.FindAsync(illustrationId);
        }

        // Crear una nueva ilustración
        public async Task<ProductIllustration> CreateIllustrationAsync(ProductIllustration illustration)
        {
            _context.ProductIlustrations.Add(illustration);
            await _context.SaveChangesAsync();
            return illustration; // Devuelve la ilustración creada
        }

        // Actualizar una ilustración existente
        public async Task<bool> UpdateIllustrationAsync(int illustrationId, ProductIllustration illustration)
        {
            var existingIllustration = await _context.ProductIlustrations.FindAsync(illustrationId);
            if (existingIllustration == null)
            {
                return false; // Si no existe la ilustración, retorna false
            }

            existingIllustration.Diagram = illustration.Diagram;
            existingIllustration.ModifiedDate = illustration.ModifiedDate;

            await _context.SaveChangesAsync();
            return true; // Retorna true si la actualización fue exitosa
        }

        // Eliminar una ilustración por ID
        public async Task<bool> DeleteIllustrationAsync(int illustrationId)
        {
            var illustration = await _context.ProductIlustrations.FindAsync(illustrationId);
            if (illustration == null)
            {
                return false; // Si no existe la ilustración, retorna false
            }

            _context.ProductIlustrations.Remove(illustration);
            await _context.SaveChangesAsync();
            return true; // Retorna true si la eliminación fue exitosa
        }
    }
}

