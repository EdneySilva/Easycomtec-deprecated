using System.Collections;
using System.Collections.Generic;

namespace Easycomtec.Lib
{
    public interface IValidationResult
    {
        IEnumerable<string> Errors();
    }
}