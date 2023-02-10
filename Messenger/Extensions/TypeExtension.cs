using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Extensions
{
    public static class TypeExtension
    {
        public static MethodInfo[] GetCreatedMethods(this Type obj)
        {
            return typeof(Messenger.Entities.UserEnity.User)
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
                .Where(m => !m.IsSpecialName 
                    & !new string[] { "Clone", "ToString", "Equals", "GetType", "GetHashCode" }
                .Contains(m.Name))
                .ToArray();
        }
    }
}
