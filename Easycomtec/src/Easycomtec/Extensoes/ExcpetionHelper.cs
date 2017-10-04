using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Extensoes
{
    public static class ExcpetionHelper
    {
        public static JsonResult AsJsonResult(this Exception ex)
        {
            return new JsonResult(new
            {
                Success = false,
                Trace = ex.StackTrace,
                Erros = ex.Errors().ToList()
            });
        }

        private static IEnumerable<string> Errors(this Exception ex)
        {
            yield return ex.Message;
            if (ex.InnerException != null)
                foreach(var inner in ex.InnerException?.Errors())
                yield return inner;
        }
    }
}
