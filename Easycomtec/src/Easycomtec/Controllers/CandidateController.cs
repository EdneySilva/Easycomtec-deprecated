using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Easycomtec.Lib;
using Easycomtec.Extensoes;
using Easycomtec.Lib.Extension;

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

        [Route("Candidate/{id}")]
        public IActionResult Candidate(int id)
        {
            var candidate = EasyRepository.Query<Candidate>()
                .Property((c) => c.Account)
                .Property((c) => c.Skills)
                .Property((c) => c.Phones)
                .Property((c) => c.Address)
                .FirstOrDefault(w => w.Id == id);
            return View(candidate);
        }

        [Route("Candidates")]
        public IActionResult Candidates()
        {
            return View(EasyRepository.Query<Candidate>().Property((c) => c.Account).ToList());
        }

        [Route("Candidate/AddPhone")]
        [HttpPost]
        public JsonResult AddPhone([FromBody]Phone phone)
        {
            try
            {
                EasyRepository.AddOrUpdate(phone).Save();
                return this.AsSuccessJsonResult(phone);
            }
            catch (Exception ex)
            {
                return ex.AsJsonResult();
            }
        }

        [Route("Candidate/RemovePhone")]
        [HttpPost]
        public JsonResult RemovePhone([FromBody]Phone phone)
        {
            try
            {
                EasyRepository.RemoveItem(phone).Save();
                return this.AsSuccessJsonResult(phone);
            }
            catch (Exception ex)
            {
                return ex.AsJsonResult();
            }
        }

        [Route("Candidate/AddSkill")]
        [HttpPost]
        public JsonResult AddSkill([FromBody]Skill skill)
        {
            try
            {
                EasyRepository.AddOrUpdate(skill).Save();
                return this.AsSuccessJsonResult(skill);
            }
            catch (Exception ex)
            {
                return ex.AsJsonResult();
            }
        }

        [Route("Candidate/RemoveSkill")]
        [HttpPost]
        public JsonResult RemoveSkill([FromBody]Skill skill)
        {
            try
            {
                EasyRepository.RemoveItem(skill).Save();
                return this.AsSuccessJsonResult();
            }
            catch (Exception ex)
            {
                return ex.AsJsonResult();
            }
        }

        public IActionResult PersonalData()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create([FromBody]Candidate candidate)
        {
            if (!this.ModelState.IsValid)
                return this.ModelState.AsJsonResult();
            try
            {
                EasyRepository.AddOrUpdate(candidate).Save();
                return this.AsSuccessJsonResult();
            }
            catch (Exception ex)
            {
                return ex.AsJsonResult();
            }
        }

        [Route("Candidate/Edit")]
        [HttpPost]
        public JsonResult Edit([FromBody]Candidate candidate)
        {
            if (!this.ModelState.IsValid)
                return this.ModelState.AsJsonResult();
            try
            {
                EasyRepository.AddOrUpdate(candidate).Save();
                return this.AsSuccessJsonResult();
            }
            catch (Exception ex)
            {
                return ex.AsJsonResult();
            }
        }
    }
}
