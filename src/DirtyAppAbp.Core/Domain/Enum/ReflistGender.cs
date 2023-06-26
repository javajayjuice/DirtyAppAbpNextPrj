using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum RefListGender : int
    {
        [Description("1. Male")]
        Male = 1,

        [Description("2. Female")]
        Female = 2,

        [Description("0. Unknown")]
        NotDisclosed = 0
    }
}
