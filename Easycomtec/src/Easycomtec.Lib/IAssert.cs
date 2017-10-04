using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Lib
{
    public interface IAssert
    {
        IValidator<T> For<T>(T item);
        //IAssert OnError(Action<IValidationResult> action);
        IValidationResult Result();
    }

    public class Assert : IAssert
    {
        IValidator CurrentValidator { get; set; }
        
        public Assert()
        {
        }
        public IValidator<T> For<T>(T item)
        {
            var validator = new Validator<T>(item, this);
            CurrentValidator = CurrentValidator ?? new Validator<T>(item, this);
            return (IValidator<T>)CurrentValidator;
        }

        public IValidationResult Result()
        {
            return CurrentValidator.Run();
        }
    }
}
