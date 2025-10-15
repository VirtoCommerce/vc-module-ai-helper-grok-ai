using System.Threading.Tasks;
using VirtoCommerce.AiHelper.Core.Models;

namespace VirtoCommerce.AiHelperGrokAi.Core.Services;
public interface IGrokAdapter
{
    Task<AiRequestResult> GetCompletionAsync(string prompt, string model = null);
}
