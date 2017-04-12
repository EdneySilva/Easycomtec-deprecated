using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Easycomtec.Lib;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Easycomtec.Controllers
{
    public class CandidateController : Controller
    {
        IRepository EasyRepository { get; set; }
        public CandidateController()
        {
         
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult PersonalData()
        {
            return View();
        }
                
        [HttpPost]
        public JsonResult Create([FromBody]Candidate candidate)
        {
            //if (!this.ModelState.IsValid) ;
            try
            {
                Repository repository = new Repository();
                repository.AddOrUpdate(candidate);
                repository.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            return Json(new
            {
            });
            //return View();
        }
    }
}
