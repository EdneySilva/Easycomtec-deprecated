using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Lib
{
    public interface IGerenciadorValidacoes
    {
        IValidator<T> Para<T>(T item);
        IGerenciadorValidacoes OnError(Action<IValidationResult> action);
        IValidationResult Validar();
    }
}
