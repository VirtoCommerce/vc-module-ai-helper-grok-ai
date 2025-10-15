using System;
using System.Threading.Tasks;
using VirtoCommerce.AiHelper.Core.Services;
using VirtoCommerce.AiHelperGrokAi.Core.Services;
using VirtoCommerce.Platform.Core.Settings;
using static VirtoCommerce.AiHelperGrokAi.Core.ModuleConstants;

namespace VirtoCommerce.AiHelperGrokAi.Data.Services;
public class GrokAiTranslationService : IAiTranslationService
{
    private readonly IGrokAdapter _grokAdapter;
    private readonly ISettingsManager _settingsManager;

    public GrokAiTranslationService(
        IGrokAdapter grokAdapter,
        ISettingsManager settingsManager
        )
    {
        _grokAdapter = grokAdapter;
        _settingsManager = settingsManager;
    }

    public virtual async Task<string> TranslateAsync(string text, string targetLanguage, string sourceLanguage = null)
    {
        var result = string.Empty;
        var translatePrompt = await _settingsManager.GetValueAsync<string>(Settings.General.AiHelperGrokAiPromptTranslate);

        if (!string.IsNullOrEmpty(translatePrompt))
        {
            translatePrompt = translatePrompt.Replace("{locale}", targetLanguage).Replace("{text}", text);

            var translationResult = await _grokAdapter.GetCompletionAsync(translatePrompt);
            if (translationResult.IsSuccess)
            {
                result = translationResult.Result;
            }
            else
            {
                throw new Exception($"Translation failed: {translationResult.ErrorMessage}");
            }
        }
        else
        {
            throw new Exception("Translation prompt is not configured.");
        }

        return result;
    }
}
