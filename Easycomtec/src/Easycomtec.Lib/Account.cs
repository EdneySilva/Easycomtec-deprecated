using Easycomtec.Lib.Extension;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easycomtec.Lib
{
    public class Account : IObject
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        [ForeignKey("Id")]
        public Candidate Candidate { get; set; }

        public IValidationResult Validate(IAssert assert)
        {
            assert.For(this).Property(p => p.Email).IsRequired("The account e-mail is required");
            assert.For(this).Property(p => p.Email).Is(p => p.IsEmail(), "The account e-mail is invalid");
            assert.For(this).Property(p => p.Password).IsRequired("The password is required");
            return assert.Result();
        }
    }
}