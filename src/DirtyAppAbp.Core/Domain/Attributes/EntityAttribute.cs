﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain.Attributes
{
    public class EntityAttribute : Attribute
    {
        public string FriendlyName { get; set; }
        public string TypeShortAlias { get; set; }
    }
}
