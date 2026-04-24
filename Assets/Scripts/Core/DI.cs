using System;
using System.Collections.Generic;

namespace Snowman.Core
{
    public static class DI
    {
        private static readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public static void Register<T>(T instance) where T : class
        {
            Type type = typeof(T);
            if (_instances.ContainsKey(type))
            {
                _instances[type] = instance;
                return;
            }
            _instances.Add(type, instance);
        }

        public static T Get<T>() where T : class
        {
            if (_instances.TryGetValue(typeof(T), out object instance))
            {
                return instance as T;
            }
            throw new InvalidOperationException($"[DI] {typeof(T).Name} is not registered.");
        }

        public static void Clear()
        {
            _instances.Clear();
        }
    }
}
