using System.Threading.Tasks;
using VirtoCommerce.AiHelper.Core.Models;
using VirtoCommerce.AiHelper.Core.Services;
using VirtoCommerce.AiHelperGrokAi.Core.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Settings;
using static VirtoCommerce.AiHelperGrokAi.Core.ModuleConstants;

namespace VirtoCommerce.AiHelperGrokAi.Data.Services;
public class GrokAiTextGenerationService : IAiTextGenerationService
{
    private readonly IGrokAdapter _grokAdapter;
    private readonly ISettingsManager _settingsManager;

    public GrokAiTextGenerationService(
        IGrokAdapter grokAdapter,
        ISettingsManager settingsManager
        )
    {
        _grokAdapter = grokAdapter;
        _settingsManager = settingsManager;
    }

    public virtual async Task<AiRequestResult> GenerateTextAsync(string prompt, string context = null)
    {
        var result = AbstractTypeFactory<AiRequestResult>.TryCreateInstance();
        if (!string.IsNullOrEmpty(prompt))
        {
            result = await _grokAdapter.GetCompletionAsync(prompt);
        }
        else
        {
            result.ErrorMessage = "Translation prompt is not configured.";
        }

        return result;
    }

    public virtual Task<string> GetTranslationPrompt()
    {
        return _settingsManager.GetValueAsync<string>(Settings.General.AiHelperGrokAiPromptTranslate);
    }

    public virtual Task<string> GetProductDescriptionGenerationPrompt()
    {
        return _settingsManager.GetValueAsync<string>(Settings.General.AiHelperGrokAiPromptDescriptionGenerate);
    }
}
