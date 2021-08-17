using System;
using System.Collections.Generic;
using System.Text;

namespace Nasigo_Parser
{
    public class NPSingleton<T> where T : class, new()
    {
        protected NPSingleton() { }

        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance { get { return instance.Value; } }
    }
}
