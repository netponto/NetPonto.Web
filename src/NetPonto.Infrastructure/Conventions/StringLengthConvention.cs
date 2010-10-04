using System;
using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NetPonto.Infrastructure.Conventions
{
    public class StringLengthConvention : AttributePropertyConvention<StringLengthAttribute>
    {
        protected override void Apply(StringLengthAttribute attribute, IPropertyInstance instance)
        {
            instance.Length(attribute.MaximumLength);
        }
    }
}