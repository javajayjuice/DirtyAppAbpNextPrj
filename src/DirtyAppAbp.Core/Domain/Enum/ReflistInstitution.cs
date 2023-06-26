using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Enum
{
    public enum ReflistInstitution
    {
        [Description("Traditional Universities")]
        Traditional_Universities,

        [Description("Universities of Technology")]
        Universities_of_Technology,

        [Description("Comprehensive University")]
        Comprehensive_University,
    }
}
