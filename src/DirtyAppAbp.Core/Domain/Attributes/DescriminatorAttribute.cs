using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Attributes
{
    internal class DescriminatorAttribute : Attribute
    {
        public string DiscriminatorColumn { get; set; }
        public bool UseDescriminator { get; set; }
        public bool FilterUnknokwnDescriminators { get; set; }

        public DescriminatorAttribute()
        {
            DiscriminatorColumn = "Person_Descrimanator";
            UseDescriminator = true;
            FilterUnknokwnDescriminators = false;
        }
    }
}
