using Easycomtec.Lib;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Validators
{
    public class RepositoryItemValidator : IModelValidator
    {
        public RepositoryItemValidator(IAssert assert)
        {
            Assert = assert;
        }

        IAssert Assert { get; set; } 
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var iObject = context.Model as IObject;
            if (iObject == null) 
                return Enumerable.Empty<ModelValidationResult>();            
            var result = iObject.Validate(Assert);
            var validation = new List<ModelValidationResult>();
            validation.AddRange(result.Errors().Select(s => new ModelValidationResult(context.Model.ToString(), s)).ToArray());
            return validation;
        }
    }
}
