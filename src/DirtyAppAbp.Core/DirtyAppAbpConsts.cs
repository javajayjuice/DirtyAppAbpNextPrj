using DirtyAppAbp.Debugging;

namespace DirtyAppAbp
{
    public class DirtyAppAbpConsts
    {
        public const string LocalizationSourceName = "DirtyAppAbp";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6597f4073f744533b1b491611b354cd5";
    }
}
