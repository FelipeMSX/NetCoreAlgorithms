using Algorithms.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public class AssemblyFactoryBase<T> where T : new()
    {

        public const string EXCEPTION_TEXT = "There isn't any type in the collection";

        private Dictionary<string, Type> _cachedTypes;

        public bool IsInitialized => _cachedTypes != null;

        public int Count => IsInitialized ? _cachedTypes.Count : 0;

        public void Initialize()
        {
            if (IsInitialized)
                return;

            var abilitiesTypes = Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(type => IsInheritanceType(type));

            _cachedTypes = new Dictionary<string, Type>();

            foreach (Type type in abilitiesTypes)
                _cachedTypes.Add(type.Name, type);
        }

        public T CreateInstance<E>() where E: T, new()
        {
            string abilityType = typeof(E).Name;

            if (_cachedTypes.Count == 0)
                throw new EmptyCollectionException(EXCEPTION_TEXT);

            bool containsType = _cachedTypes.ContainsKey(abilityType);

            return CreateType(typeof(E));
        }


        private static bool IsInheritanceType(Type type) => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T));
        private static T CreateType(T type)=>new T();
        
    }
}
