using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.AiHelper.Core.Models;
using VirtoCommerce.AiHelperGrokAi.Core.Services;
using VirtoCommerce.Platform.Core.Settings;
using static VirtoCommerce.AiHelperGrokAi.Core.ModuleConstants;

namespace VirtoCommerce.AiHelperGrokAi.Data.Services;
public class GrokAdapter : IGrokAdapter
{
    private readonly ISettingsManager _settingsManager;
    public GrokAdapter(ISettingsManager settingsManager)
    {
        _settingsManager = settingsManager;
    }

    public virtual async Task<AiRequestResult> GetCompletionAsync(string prompt, string model = null)
    {
        var result = new AiRequestResult();

        var grokServiceUrl = await _settingsManager.GetValueAsync<string>(Settings.General.AiHelperGrokAiUrl);
        var apiKey = await _settingsManager.GetValueAsync<string>(Settings.General.AiHelperGrokAiKey);

        if (!string.IsNullOrEmpty(grokServiceUrl) && !string.IsNullOrEmpty(apiKey))
        {
            if (string.IsNullOrEmpty(model))
            {
                model = await _settingsManager.GetValueAsync<string>(Settings.General.AiHelperGrokAiModel);
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var requestBody = new
                {
                    model = model,
                    messages = new[]
                    {
                        new { role = "user", content = prompt }
                    },
                    max_tokens = 100000
                };

                var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(grokServiceUrl, content);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    using (var jsonDoc = System.Text.Json.JsonDocument.Parse(responseBody))
                    {
                        var choices = jsonDoc.RootElement.GetProperty("choices");
                        var firstChoice = choices[0];
                        var message = firstChoice.GetProperty("message");
                        result.Result = message.GetProperty("content").GetString();
                    }

                    result.IsSuccess = true;
                }
                catch (HttpRequestException e)
                {
                    result.ErrorMessage = e.Message;
                }

            }
        }
        else
        {
            result.ErrorMessage = "GrokAI service URL or API key is not configured.";
        }

        return result;
    }
}
