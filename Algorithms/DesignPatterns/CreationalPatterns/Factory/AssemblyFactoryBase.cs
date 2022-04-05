using Algorithms.Collections.TreeTraversalStrategies;
using Algorithms.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    //This is only suitable for stateless strategies.
    public abstract class AssemblyFactoryBase<T> where T : class
    {
        public const string EMPTY_COLLECTION = "There isn't any type in the collection";

        public bool IsInitialized => _cachedTypes != null;

        public int Count => IsInitialized ? _cachedTypes.Count : 0;

        private Dictionary<string, T> _cachedTypes;

        protected AssemblyFactoryBase()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (IsInitialized)
                return;


            Type typeOfT = typeof(T);
            var x = Assembly.GetAssembly(typeOfT).GetTypes();
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

        private bool CheckInstanceType(Type typeOfT, Type type)
        {
            bool isClass = typeOfT.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;

            if (isClass)
                return true;

            var interfaces = type.GetInterfaces();

            bool isInterface = type.GetInterfaces()
                .Any(i => typeOfT.IsGenericType && i.IsGenericType && i.BaseType == typeOfT.BaseType);

            if (isInterface)
                return true;

            return false;
        }

        private static T CreateType(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

    }
}
