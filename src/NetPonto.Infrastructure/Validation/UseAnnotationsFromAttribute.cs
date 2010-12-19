using System;

namespace NetPonto.Infrastructure.Validation
{
    /// <summary>
    /// Marks a class as using data annotations from another type.
    /// This will be done per property, for properties not anotated with attributes
    /// </summary>
    /// <remarks>
    /// If a given property is anotated with attributes, then those are used instead of the import.
    /// </remarks>
    public class UseAnnotationsFromAttribute : Attribute
    {
        public Type Type { get; private set; }

        public UseAnnotationsFromAttribute(Type type)
        {
            Type = type;
        }
    }
}