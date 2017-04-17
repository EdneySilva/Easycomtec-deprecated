using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Easycomtec.Lib;

namespace Easycomtec.Validators
{
    public class RepositoryValidatorProvider : IModelValidatorProvider
    {
        public void CreateValidators(ModelValidatorProviderContext context)
        {
            if (!context.ModelMetadata.ModelType.GetInterfaces().Contains(typeof(IObject)))
                return;
            var validatorItem = new ValidatorItem();
            validatorItem.Validator = new RepositoryItemValidator(new Assert());
            context.Results.Add(validatorItem);
        }
    }
}
