using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;
using static VirtoCommerce.AiHelper.Core.ModuleConstants;

namespace VirtoCommerce.AiHelperGrokAi.Core;

public static class ModuleConstants
{
    public static class Providers
    {
        public const string GrokAi = "GrokAI";
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor AiHelperGrokAiUrl { get; } = new()
            {
                Name = "AiHelperGrokAi.Url",
                GroupName = "AiHelper|GrokAI",
                ValueType = SettingValueType.ShortText,
                DefaultValue = "https://api.x.ai/v1/chat/completions",
            };

            public static SettingDescriptor AiHelperGrokAiModel { get; } = new()
            {
                Name = "AiHelperGrokAi.Model",
                GroupName = "AiHelper|GrokAI",
                ValueType = SettingValueType.ShortText,
                AllowedValues = ["grok-4-fast-reasoning", "grok-4-fast-non-reasoning", "grok-3-mini"],
                DefaultValue = "grok-4-fast-reasoning",
            };

            public static SettingDescriptor AiHelperGrokAiKey { get; } = new()
            {
                Name = "AiHelperGrokAi.Key",
                GroupName = "AiHelper|GrokAI",
                ValueType = SettingValueType.SecureString,
            };

            public static SettingDescriptor AiHelperGrokAiPromptTranslate { get; } = new()
            {
                Name = "AiHelperGrokAi.PromptTranslate",
                GroupName = "AiHelper|Prompts - GrokAI",
                ValueType = SettingValueType.LongText,
                DefaultValue = DefaultPrompts.Translation,
            };

            public static SettingDescriptor AiHelperGrokAiPromptDescriptionGenerate { get; } = new()
            {
                Name = "AiHelperGrokAi.PromptDescriptionGenerate",
                GroupName = "AiHelper|Prompts - GrokAI",
                ValueType = SettingValueType.LongText,
                DefaultValue = DefaultPrompts.ProductDescriptionGeneration,
            };

            public static IEnumerable<SettingDescriptor> AllGeneralSettings
            {
                get
                {
                    yield return AiHelperGrokAiUrl;
                    yield return AiHelperGrokAiModel;
                    yield return AiHelperGrokAiKey;
                    yield return AiHelperGrokAiPromptTranslate;
                    yield return AiHelperGrokAiPromptDescriptionGenerate;
                }
            }
        }

        public static IEnumerable<SettingDescriptor> AllSettings
        {
            get
            {
                return General.AllGeneralSettings;
            }
        }
    }
}
