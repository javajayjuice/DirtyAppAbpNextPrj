using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistProvince
    {
        [Description("Eastern Cape")]
        EasternCape,

        [Description("Free State")]
        FreeState,

        [Description("Gauteng")]
        Gauteng,

        [Description("KwaZulu-Natal")]
        KwaZuluNatal,

        [Description("Limpopo")]
        Limpopo,

        [Description("Mpumalanga")]
        Mpumalanga,

        [Description("Northern Cape")]
        NorthernCape,

        [Description("North West")]
        NorthWest,

        [Description("Western Cape")]
        WesternCape
    }
}
