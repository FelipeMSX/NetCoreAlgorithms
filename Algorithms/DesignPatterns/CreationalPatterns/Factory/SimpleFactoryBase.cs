using System;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public abstract class SimpleFactoryBase<T> where T : class
    {

        protected SimpleFactoryBase()
        {      
        }

        public T CreateInstance<E>() where E : T, new()
        {
           return new E();
        }

        public T CreateInstance<E>(params object[] args) where E : T, new()
        {
            return (E)Activator.CreateInstance(typeof(E), args);
        }
    }
}
