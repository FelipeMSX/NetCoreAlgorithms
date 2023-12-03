
namespace OmegaCore.Interfaces
{
    public interface IOmegaComparator<T>
    {
        /// <summary>
        /// <inheritdoc cref="OmegaComparison{T}"></inheritdoc>
        /// </summary>
        OmegaComparison<T> Comparator { get; }
    }


    /// <summary>
    ///  Represents the method that compares two objects of the same type.
    /// </summary>
    /// <param name="x"> The first object to compare.</param>
    /// <param name="y"> The second object to compare.</param>
    /// <returns>
    ///  Returns A signed integer that indicates the relative values of x and y, as shown in the
    ///  <para>
    ///    Following table.
    ///  </para>
    ///  <para>
    ///  <b>Less than 0</b> <paramref name="x"/> is less than <paramref name="y"/>.
    ///  </para>
    ///  <para>
    ///  <b>0</b> <paramref name="x"/> equals <paramref name="y"/>.
    ///  </para>
    ///  <para>
    ///  <b>Greater than 0</b> <paramref name="x"/> is greater than <paramref name="y"/>.
    ///  </para>
    /// </returns>
    public delegate int OmegaComparison<in T>(T x, T y);
}
