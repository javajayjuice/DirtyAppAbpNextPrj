using System.ComponentModel;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistStatus
    {
        [Description("Submitted")]
        Submitted,

        [Description("Pending")]
        Pending,

        [Description("Regected")]
        Regected,

        [Description("Accepted")]
        Accepted,
    }
}
