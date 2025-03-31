using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Interface
{
    public interface IProductIllustrationRepository
    {
        Task<IEnumerable<ProductIllustration>> GetIllustrationsAsync();
        Task<ProductIllustration?> GetIllustrationByIdAsync(int illustrationId);
        Task<ProductIllustration> CreateIllustrationAsync(ProductIllustration illustration);
        Task<bool> UpdateIllustrationAsync(int illustrationId, ProductIllustration illustration);
        Task<bool> DeleteIllustrationAsync(int illustrationId);
    }
}
