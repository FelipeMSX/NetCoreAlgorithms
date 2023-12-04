namespace AssemblyFactoryMethod
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    /// <typeparam name="TType">The type of the object to be cached.</typeparam>
    public interface IAssemblyFactoryMethod<TType, TEnum>
    {
        /// <summary>
        /// The numbers of cached types of <typeparamref name="TType"/>
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Creates an instance of <typeparamref name="TType"/>
        /// </summary>
        /// <returns> Returns a new instance of the requested type.</returns>>
        TType CreateInstance(TEnum value);

        /// <summary>
        /// <inheritdoc cref="IAssemblyFactoryMethod{TType, TEnum}.CreateInstance(TEnum)"/>
        /// </summary>
        /// <returns><inheritdoc cref="IAssemblyFactoryMethod{TType, TEnum}.CreateInstance(TEnum)"/></returns>
        TType CreateInstance(TEnum value, params object[] args);
    }
}