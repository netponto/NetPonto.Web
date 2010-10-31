using System;

namespace NetPonto.Infrastructure.Validation
{
    public class UseAnnotationsFromAttribute : Attribute
    {
        public Type Type { get; private set; }

        public UseAnnotationsFromAttribute(Type type)
        {
            Type = type;
        }
    }
}