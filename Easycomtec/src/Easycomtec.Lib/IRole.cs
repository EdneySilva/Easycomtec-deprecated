
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Easycomtec.Lib
{
    public interface IRole<T>
    {
        string Message { get; }
        IValidationResult Test(T context);
    }

    public interface IRole<T, TP> : IRole<T>
    {
        IRole<T, TP> IsRequired(string message = null);
        IRole<T, TP> IsNotEmpty(string message = null);
    }

    class Role<T, TP> : IRole<T, TP>
    {
        public string Message { get; private set; }
        TP Default { get; set; }
        Func<T, TP> Context { get; set; }
        Func<T, Role<T, TP>, bool> RolesToExecute { get; set; }
        public IRole<T, TP> IsNotEmpty(string message = null)
        {
            Message = message ?? "The Item cannot be empty";
            var type = typeof(TP);
            if (!typeof(TP).GetTypeInfo().GetInterfaces().Contains(typeof(IEnumerable)))
                throw new InvalidOperationException("It is not possible use a Collection role in a non collection item");
            RolesToExecute = (item, role) =>
            {
                var collection = role.Context(item);
                if (collection as IEnumerable == null)
                    return false;
                foreach (var obj in (collection as IEnumerable))
                    return true;
                return false;
            };
            return this;
        }

        public IRole<T, TP> IsRequired(string message = null)
        {
            Message = message ?? "The Item is required";
            RolesToExecute = (item, role) =>
            {
                var value = role.Context(item);
                if (value == null)
                    return false;
                if (role.Default.GetType().Name.Equals("String"))
                    return role.Context(item).ToString().Length > 0;
                object _default = role.Default;
                object _result = role.Context(item);
                return _default == _result;
            };
            return this;
        }

        public IValidationResult Test(T context)
        {
            RolesToExecute(context, this);
            return null;
        }
    }
}