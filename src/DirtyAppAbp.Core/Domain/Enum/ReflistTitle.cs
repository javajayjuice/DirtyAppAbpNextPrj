using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistTitle
    {
        [Description("Mr")]
        Mr,

        [Description("Mrs")]
        Mrs,

        [Description("Miss")]
        Miss,

        [Description("Ms")]
        Ms,
    }
}
