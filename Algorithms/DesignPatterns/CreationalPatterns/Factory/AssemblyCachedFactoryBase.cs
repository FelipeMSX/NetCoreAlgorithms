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
        public bool IsInitialized => _cachedTypes != null;

        public int Count => IsInitialized ? _cachedTypes.Count : 0;

        private static Dictionary<string, Type> _cachedTypes;

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

            _cachedTypes = new Dictionary<string, Type>();

            foreach (Type type in abilitiesTypes)
            {
                _cachedTypes.Add(type.Name, type);
            }
        }

        public T CreateInstance<E>() where E : T, new()
        {
            if (_cachedTypes.Count == 0)
                throw new EmptyCollectionException();

            string className = typeof(E).Name;

           return _cachedTypes[className];
        }

        public T CreateInstance<E>(params object[] arg) where E : T, new()
        {
            if (_cachedTypes.Count == 0)
                throw new EmptyCollectionException();

            string className = typeof(E).Name;

            return _cachedTypes[className];
        }



        private static bool CheckInstanceType(Type typeOfT, Type type)
        {
            bool isDerived = typeOfT.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;

            return isDerived;
        }

        private static T CreateInstanceInternal(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

        private static T CreateInstanceInternal<E>(params object[] args) where E : T
        {
            return (T)Activator.CreateInstance(typeof(E), args);
        }
    }
}
