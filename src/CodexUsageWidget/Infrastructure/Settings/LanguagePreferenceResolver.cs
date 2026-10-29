using System.Globalization;

namespace CodexUsageWidget.Infrastructure.Settings;

public static class LanguagePreferenceResolver
{
    public static LanguagePreference Resolve(LanguagePreference preference, CultureInfo uiCulture)
    {
        if (preference != LanguagePreference.System)
        {
            return preference;
        }

        for (var current = uiCulture; !string.IsNullOrEmpty(current.Name); current = current.Parent)
        {
            if (Matches(current.Name, "zh-Hant", "zh-TW", "zh-HK", "zh-MO"))
                return LanguagePreference.TraditionalChinese;

            if (Matches(current.Name, "zh-Hans", "zh-CN", "zh-SG"))
                return LanguagePreference.SimplifiedChinese;
        }

        return LanguagePreference.English;
    }

    private static bool Matches(string name, params string[] supportedCultures) =>
        supportedCultures.Any(supported =>
            string.Equals(name, supported, StringComparison.OrdinalIgnoreCase));
}
