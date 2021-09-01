using Algorithms.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public class AssemblyFactoryBase<T>
    {
        private Dictionary<string, Type> _cachedTypes;

        public bool IsInitialized => _cachedTypes != null;
        public string NullableClassName { get; private set; }

        public int Count => IsInitialized ? _cachedTypes.Count : 0;

        public void Initialize(string nullableClassName)
        {
            NullableClassName = nullableClassName;
            
            if (IsInitialized)
                return;

            var abilitiesTypes = Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(type => IsInheritanceType(type));

            _cachedTypes = new Dictionary<string, Type>();

            foreach (Type type in abilitiesTypes)
            {
                _cachedTypes.Add(type.Name, type);
            }
        }

        public T CreateInstance(string abilityType) 
        {
            if (_cachedTypes.Count == 0)
                throw new EmptyCollectionException("There isn't any type in the collection");

            return _cachedTypes.ContainsKey(abilityType) ? CreateType(abilityType) : CreateType(NullableClassName);
        }


        private bool IsInheritanceType(Type type) => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T));
        private T CreateType(string key) => (T)Activator.CreateInstance(_cachedTypes[key]);
    }
}
