using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Algorithms.Exceptions;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    //This is only suitable for stateless strategies.
    /// <summary>
    /// This is only suitable for stateless strategies.
    /// It works with abstract and interfaces.
    /// It doesn`t support generic parameters.
    /// </summary>
    public abstract class AssemblyCachedFactoryBase<T> where T : class
    {
        public const string EMPTY_COLLECTION = "There isn't any type in the collection";

        public bool IsInitialized => _cachedTypes != null;

        public int Count => IsInitialized ? _cachedTypes.Count : 0;

        private Dictionary<string, T> _cachedTypes;

        protected AssemblyCachedFactoryBase()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (IsInitialized)
                return;

            Type typeOfT = typeof(T);
            var abilitiesTypes = Assembly.GetAssembly(typeOfT).GetTypes().Where(t => CheckInstanceType(typeOfT,t));

            _cachedTypes = new Dictionary<string, T>();

            foreach (Type type in abilitiesTypes)
            {
                _cachedTypes.Add(type.Name, CreateType(type));
            }
        }

        public T GetFactory<E>() where E : T, new()
        {
            if (_cachedTypes.Count == 0)
                throw new EmptyCollectionException(EMPTY_COLLECTION);

            string className = typeof(E).Name;

           return _cachedTypes[className];
        }

        private static bool CheckInstanceType(Type typeOfT, Type type)
        {
            bool isDerived = typeOfT.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;

            return isDerived;
        }

        private static T CreateType(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}
