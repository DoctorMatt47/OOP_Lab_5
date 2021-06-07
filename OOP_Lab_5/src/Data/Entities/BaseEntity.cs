namespace OOP_Lab_5.Data.Entities
{
    /// <summary>
    /// Abstract base class for entities.
    /// Provides id getter and setter.
    /// </summary>
    /// <typeparam name="T">Id type</typeparam>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Provides getter and setter for Id.
        /// </summary>
        public virtual T Id { get; set; }
    }
}
