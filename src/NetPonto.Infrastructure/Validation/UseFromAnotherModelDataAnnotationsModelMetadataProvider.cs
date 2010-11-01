using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NetPonto.Infrastructure.Validation
{
    /// <summary>
    /// Allows the "importing" of metadata from a model to another based on property names (which must be equal on both models).
    /// </summary>
    /// <remarks>
    /// If a given property is anotated with attributes, then those are used instead of the import.
    /// </remarks>
    public class UseFromAnotherModelDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType,
                                                        Func<object> modelAccessor, Type modelType, string propertyName)
        {
            if (containerType != null && !string.IsNullOrEmpty(propertyName))
            {
                if (containerType.GetProperty(propertyName).GetCustomAttributes(false).Any())
                {
                    return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
                }
            }

            var importedTypes = (containerType ?? modelType).GetCustomAttributes(typeof (UseAnnotationsFromAttribute),
                                                                                 false)
                .Cast<UseAnnotationsFromAttribute>()
                .Select(a => a.Type);

            var numberOfImportedTypes = importedTypes.Count();
            if (numberOfImportedTypes == 0)
            {
                return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            }
            if (numberOfImportedTypes > 1)
            {
                throw new InvalidOperationException(string.Format("Too many imported types on {0}:{1}", containerType,
                                                                  string.Join(", ", importedTypes.Select(t => t.ToString()).ToArray())));
            }
            return base.CreateMetadata(attributes, importedTypes.Single(), modelAccessor, modelType, propertyName);
        }
    }
}