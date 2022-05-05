using System;

namespace Algorithms.DesignPatterns.CreationalPatterns.Factory
{
    public abstract class SimpleFactoryBase<T> where T : class
    {

        protected SimpleFactoryBase()
        {      
        }

        public T CreateInstance<E>() where E : T
        {
           return (T)Activator.CreateInstance(typeof(E));
        }

        //Maybe this can be a performance hit whether it`s invoked many times.
        public T CreateInstance<E>(params object[] args) where E : T
        {
            return (T)Activator.CreateInstance(typeof(E), args);
        }
    }
}
