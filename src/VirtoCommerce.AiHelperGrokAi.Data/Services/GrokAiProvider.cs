using VirtoCommerce.AiHelper.Core.Services;
using VirtoCommerce.AiHelperGrokAi.Core;

namespace VirtoCommerce.AiHelperGrokAi.Data.Services;
public class GrokAiProvider : AbstractAiProvider
{
    public override string ProviderName => ModuleConstants.Providers.GrokAi;
    public override string ProviderType => nameof(GrokAiProvider);

}

