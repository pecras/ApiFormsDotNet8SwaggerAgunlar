using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForms.DTOS
{
    public class LoanDetailsDto
    {
        public string BankName { get; set; } = string.Empty;
    public decimal LoanAmount { get; set; }
    public decimal EMI { get; set; }
    }
}