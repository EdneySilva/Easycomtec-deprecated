using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Easycomtec.Lib
{
    public class Repository : DbContext, IRepository
    {
        internal DbSet<Candidate> Candidate { get; set; }
        internal DbSet<Address> CandidateAddress { get; set; }
        internal DbSet<Account> CandidateAccount { get; set; }
        internal DbSet<Skill> CandidateSkill { get; set; }
        internal DbSet<Phone> CandidatePhone { get; set; }
        
        public IRepository For<T>(T teste)
        {
            
            return this;
        }

        public void TryAddAsync()
        {
        }
    }
}
