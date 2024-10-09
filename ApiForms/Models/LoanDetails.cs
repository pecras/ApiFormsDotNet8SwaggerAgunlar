using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForms.Models
{
    public class LoanDetails
    {
        public int LoanID { get; set; }
    public int ApplicationID { get; set; } // Chave estrangeira
    public string BankName { get; set; } = string.Empty;
    public decimal LoanAmount { get; set; }
    public decimal EMI { get; set; }
        
    }
}