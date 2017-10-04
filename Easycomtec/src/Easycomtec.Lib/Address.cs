using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easycomtec.Lib
{
    public class Address : IObject
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public Address()
        {

        }

        public IValidationResult Validate(IAssert gerenciador)
        {
            gerenciador.For(this).Property(p => p.City).IsRequired("The city is required");
            gerenciador.For(this).Property(p => p.State).IsRequired("The state is required");
            gerenciador.For(this).Property(p => p.Country).IsRequired("The country is required");
            return gerenciador.Result();
        }
    }
}