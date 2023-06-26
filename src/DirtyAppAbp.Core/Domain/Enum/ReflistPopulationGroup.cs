using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistPopulationGroup
    {
        [Description("African")]
        African,

        [Description("Coloured")]
        Coloured,

        [Description("Indian")]
        Indian,

        [Description("White")]
        White,

        [Description("Asian")]
        Asian
    }
}
