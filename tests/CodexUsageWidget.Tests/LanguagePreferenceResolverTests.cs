using System.Globalization;
using CodexUsageWidget.Infrastructure.Settings;

namespace CodexUsageWidget.Tests;

public sealed class LanguagePreferenceResolverTests
{
    [Theory]
    [InlineData("en-US", LanguagePreference.English)]
    [InlineData("fr-FR", LanguagePreference.English)]
    [InlineData("zh-TW", LanguagePreference.TraditionalChinese)]
    [InlineData("zh-HK", LanguagePreference.TraditionalChinese)]
    [InlineData("zh-MO", LanguagePreference.TraditionalChinese)]
    [InlineData("zh-Hant", LanguagePreference.TraditionalChinese)]
    [InlineData("zh-CN", LanguagePreference.SimplifiedChinese)]
    [InlineData("zh-SG", LanguagePreference.SimplifiedChinese)]
    [InlineData("zh-Hans", LanguagePreference.SimplifiedChinese)]
    public void ResolveSystemUsesSupportedWindowsCultureOrEnglishFallback(
        string cultureName,
        LanguagePreference expected)
    {
        Assert.Equal(
            expected,
            LanguagePreferenceResolver.Resolve(
                LanguagePreference.System,
                CultureInfo.GetCultureInfo(cultureName)));
    }

    [Theory]
    [InlineData(LanguagePreference.English, "zh-CN")]
    [InlineData(LanguagePreference.SimplifiedChinese, "en-US")]
    [InlineData(LanguagePreference.TraditionalChinese, "en-US")]
    [InlineData(LanguagePreference.TraditionalChinese, "zh-CN")]
    public void ResolveExplicitPreferenceOverridesWindowsCulture(
        LanguagePreference preference,
        string cultureName)
    {
        Assert.Equal(
            preference,
            LanguagePreferenceResolver.Resolve(
                preference,
                CultureInfo.GetCultureInfo(cultureName)));
    }
}
