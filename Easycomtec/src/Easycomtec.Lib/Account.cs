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
        
    }
}