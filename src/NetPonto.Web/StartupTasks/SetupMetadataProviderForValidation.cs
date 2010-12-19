using System;
using System.Web.Mvc;
using NetPonto.Infrastructure.StartupTasks;
using NetPonto.Infrastructure.Validation;

namespace NetPonto.Web.StartupTasks
{
    public class SetupMetadataProviderForValidation : IStartupTask
    {
        public void Execute()
        {
            ModelMetadataProviders.Current = new UseFromAnotherModelDataAnnotationsModelMetadataProvider();
        }
    }
}