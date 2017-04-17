using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Easycomtec.Lib
{
    public class Candidate : IObject
    {
        public Candidate()
        {
            Skills = new List<Skill>();
            Phones = new List<Phone>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        //public virtual PaymentInformation PaymentInformation { get; set; }
        public virtual Address Address { get; set; }
        public Account Account { get; set; }

        public IValidationResult Validate(IAssert assert)
        {
            assert.For(this).Property(p => p.Name).IsRequired();
            assert.For(this).Property(p => p.BirthDate).IsRequired();
            assert.For(this).Property(p => p.Skills).IsNotEmpty();
            assert.For(this).Property(p => p.Phones).IsNotEmpty();
            return assert.Result();
        }
    }
}
