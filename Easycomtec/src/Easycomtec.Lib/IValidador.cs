using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Easycomtec.Lib
{
    public interface IValidator
    {
        IValidationResult Run();
    }

    public interface IValidator<T> : IValidator
    {
        IRole<T, TP> Property<TP>(Func<T, TP> configure);
    }

    public class Validator<T>  : IValidator<T>
    {
        ICollection<IRole<T>> Roles { get; set; }
        IAssert AssertContext { get; set; }
        T Context { get; }
        public Validator(T context, IAssert assert)
        {
            Context = context;
            AssertContext = assert;
        }
        
        public IValidationResult Run()
        {
            IValidationResult result = new ValidationResult();
            Roles.AsParallel().Select((s) => s.Test(Context)).ToArray();
            return result;
        }

        public IRole<T, TP> Property<TP>(Func<T, TP> configure)
        {
            var role = new Role<T, TP>();
            Roles.Add(role);
            return role;
        }
    }
}