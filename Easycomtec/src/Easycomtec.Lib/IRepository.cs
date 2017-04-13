using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Lib
{
    public interface IRepository
    {
        IRepository AddOrUpdate<T>(T item) where T : class, IObject;
        void Save();
    }
}
