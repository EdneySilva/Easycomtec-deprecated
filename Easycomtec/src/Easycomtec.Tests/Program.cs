using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easycomtec.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (CandidateTest test = new CandidateTest())
            {
                test.GoToForms().CreateNewAccount();
            }
        }
    }
}
