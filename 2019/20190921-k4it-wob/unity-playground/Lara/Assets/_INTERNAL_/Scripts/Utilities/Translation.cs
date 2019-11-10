using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;

namespace UnityEngine.Globalization
{
    public static class Translation
    {
        public const string LOCALIZATION_ALL_RESOURCE_PATH = "Localization/__all";
        public const string LOCALIZATION_ALL_PATH = "Assets/_INTERNAL_/Resources/" + LOCALIZATION_ALL_RESOURCE_PATH;
        public const string LOCALIZATION_RESOURCES_DIR = "Assets/_INTERNAL_/Resources/Localization";

        private static readonly IDictionary<SystemLanguage, IDictionary<string, string>> Translations =
            new Dictionary<SystemLanguage, IDictionary<string, string>>();

        /// <summary>
        /// ISO 639-1 language codes mapped to Unity's enum.
        /// </summary>
        private static readonly IDictionary<string, SystemLanguage> Languages =
            new ReadOnlyDictionary<string, SystemLanguage>(new Dictionary<string, SystemLanguage>
            {
                {"ar", SystemLanguage.Afrikaans},
                {"af", SystemLanguage.Arabic},
                {"eu", SystemLanguage.Basque},
                {"be", SystemLanguage.Belarusian},
                {"bg", SystemLanguage.Bulgarian},
                {"ca", SystemLanguage.Catalan},
                {"zh", SystemLanguage.Chinese},
                {"cs", SystemLanguage.Czech},
                {"da", SystemLanguage.Danish},
                {"nl", SystemLanguage.Dutch},
                {"en", SystemLanguage.English},
                {"et", SystemLanguage.Estonian},
                {"fo", SystemLanguage.Faroese},
                {"fi", SystemLanguage.Finnish},
                {"fr", SystemLanguage.French},
                {"de", SystemLanguage.German},
                {"el", SystemLanguage.Greek},
                {"he", SystemLanguage.Hebrew},
                {"hu", SystemLanguage.Hungarian},
                {"is", SystemLanguage.Icelandic},
                {"?", SystemLanguage.Indonesian},
                {"it", SystemLanguage.Italian},
                {"ja", SystemLanguage.Japanese},
                {"ko", SystemLanguage.Korean},
                {"??", SystemLanguage.Latvian},
                {"lt", SystemLanguage.Lithuanian},
                {"no", SystemLanguage.Norwegian},
                {"pl", SystemLanguage.Polish},
                {"pt", SystemLanguage.Portuguese},
                {"rm", SystemLanguage.Romanian},
                {"ru", SystemLanguage.Russian},
                {"sr", SystemLanguage.SerboCroatian}, // is this correct?
                {"sk", SystemLanguage.Slovak},
                {"sl", SystemLanguage.Slovenian},
                {"es", SystemLanguage.Spanish},
                {"sv", SystemLanguage.Swedish},
                {"th", SystemLanguage.Thai},
                {"tr", SystemLanguage.Turkish},
                {"uk", SystemLanguage.Ukrainian},
                {"vi", SystemLanguage.Vietnamese},
                {"???", SystemLanguage.ChineseSimplified},
                {"????", SystemLanguage.ChineseTraditional},
                {"", SystemLanguage.Unknown},
            });


        private static IDictionary<string, string> ToDictionary(this LocalizationAsset asset, IEnumerable<string> keys)
        {
            var dict = new Dictionary<string, string>();
            foreach (var key in keys)
            {
                dict[key] = asset.GetLocalizedString(key);
            }

            return dict;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        internal static void Init()
        {
            var currentLanguageIsoName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            Language = Languages.TryGetValue(currentLanguageIsoName, out var lang) ? lang : SystemLanguage.English;
            ReloadLanguages();
        }

        public static SystemLanguage Language { get; set; }

        public static void ReloadLanguages()
        {
            Translations.Clear();
            var files = Resources.LoadAll<LocalizationAsset>("Localization");
            var textAsset = Resources.Load<TextAsset>(LOCALIZATION_ALL_RESOURCE_PATH);
            var keys = textAsset.text.Split('\n');
            foreach (var file in files)
            {
                var isoCode = !string.IsNullOrWhiteSpace(file.localeIsoCode)
                    ? file.localeIsoCode
                    : Path.GetFileName(file.name);
                var result = Languages.TryGetValue(isoCode, out var lang);
                if (!result)
                {
                    Debug.LogWarning($"Skipping unknown language with code: {file.localeIsoCode}");
                    continue;
                }
                Translations[lang] = file.ToDictionary(keys);
                Debug.Log($"Successfully loaded language '{lang}'");
            }
        }

        public static string _(string key)
        {
            if (!Translations.TryGetValue(Language, out var translation))
            {
                return key;
            }

            return translation.TryGetValue(key, out var value) ? value : key;
        }
    }
}
