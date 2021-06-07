namespace OOP_Lab_5.Core.Prototype
{
    /// <summary>
    /// Represents interface for cloneable objects.
    /// Implements prototype pattern.
    /// </summary>
    public interface IPrototype
    {
        /// <summary>
        /// Creates clone of this object.
        /// </summary>
        /// <returns>clone of this object.</returns>
        IPrototype Clone();
    }
}
