﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayraPlatform.Domain.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditableAttribute : Attribute
    {
    }
}
