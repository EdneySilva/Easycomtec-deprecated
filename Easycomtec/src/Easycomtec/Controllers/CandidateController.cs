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
        public CandidateController(IRepository repository)
        {
            EasyRepository = repository;
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

        [HttpPost]
        public IActionResult Create(Candidate candidate)
        {
            if (this.ModelState.IsValid) ;
            
            return View();
        }
    }
}
