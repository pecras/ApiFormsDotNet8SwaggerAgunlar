using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForms.Models
{
    public class LoanApplicationForm
   {
    public int ApplicationID { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public decimal Income { get; set; }
    public string EmploymentStatus { get; set; } = string.Empty;
    public int CreditScore { get; set; }
    public string Assets { get; set; } = string.Empty;
    
    // Lista de empréstimos associados
    public List<LoanDetails> Loans { get; set; } = new();
}
}