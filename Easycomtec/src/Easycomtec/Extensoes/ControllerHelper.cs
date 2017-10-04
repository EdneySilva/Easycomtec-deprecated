using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Extensoes
{
    public static class ControllerHelper
    {
        public static JsonResult AsSuccessJsonResult(this Controller controller, string message = "Operação realizada com sucesso!")
        {
            return new JsonResult(new
            {
                Success = true,
                Message = message
            });
        }

        public static JsonResult AsSuccessJsonResult<T>(this Controller controller, T model, string message = "Operação realizada com sucesso!")
        {
            return new JsonResult(new
            {
                Model = model,
                Success = true,
                Message = message
            });
        }
    }
}
