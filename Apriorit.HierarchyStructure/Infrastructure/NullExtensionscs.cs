using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apriorit.HierarchyStructure.Mvc.Infrastructure
{
    public static class NullExtensions
    {
        public static void ThrowIfNull(this object obj, string element)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(element);
            }
        }
    }
}