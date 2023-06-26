using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Attributes
{
    public class DescriminatorValue : Attribute
    {
        public object Value { get; set; }

        public DescriminatorValue(object value)
        {
            Value = value;
        }
    }
}
