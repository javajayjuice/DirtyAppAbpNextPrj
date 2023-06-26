using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DirtyAppAbp.Localization
{
    public static class DirtyAppAbpLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DirtyAppAbpConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DirtyAppAbpLocalizationConfigurer).GetAssembly(),
                        "DirtyAppAbp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
