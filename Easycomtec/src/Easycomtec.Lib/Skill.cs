using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easycomtec.Lib
{
    public class Skill : IObject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public IValidationResult Validate(IAssert assert)
        {
            throw new NotImplementedException();
        }
    }
}