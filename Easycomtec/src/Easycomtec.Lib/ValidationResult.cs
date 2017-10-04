using System;
using System.Collections.Generic;
using System.Linq;

namespace Easycomtec.Lib
{ 
    class ValidationResult : IValidationResult
    {
        private List<string> ErrorList { get; } = new List<string>();
        
        public ValidationResult(bool result, string error)
        {
            if (result)
                ErrorList.Add(error);
        }

        public ValidationResult(params IValidationResult[] validations)
        {
            ErrorList.AddRange(validations.SelectMany(s => s.Errors()));
        }

        public IEnumerable<string> Errors()
        {
            return ErrorList;
        }
    }
}