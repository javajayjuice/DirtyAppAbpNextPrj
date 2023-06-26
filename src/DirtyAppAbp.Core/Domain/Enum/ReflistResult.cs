using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public  enum ReflistResult
    {
        [Description("Cancelled")]
        Cancelled,

        [Description("Failed")]
        Failed,

        [Description("Degree Obtained")]
        DegreeObtained,

    }
}
