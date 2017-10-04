using Easycomtec.Lib.Extension;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easycomtec.Lib
{
    public class Phone : IObject
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public IValidationResult Validate(IAssert assert)
        {
            assert.For(this).Property(item => item.Number).Is((p) => p.IsPhoneNumber(), "The phone number is invalid");
            return assert.Result();
        }
    }
}