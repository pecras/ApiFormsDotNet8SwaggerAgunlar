using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiForms.Models;
using ApiForms.DTOS;

namespace ApiForms.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoanApplicationFormsController : ControllerBase
    {
    // Lista temporária simulando um banco de dados
    private static List<LoanApplicationForm> loanApplications = new();

    [HttpGet]
    public ActionResult<List<LoanApplicationForm>> GetAll()
    {
        return Ok(loanApplications);
    }

    [HttpGet("{id}")]
    public ActionResult<LoanApplicationForm> GetById(int id)
    {
        var loanApplication = loanApplications.FirstOrDefault(x => x.ApplicationID == id);
        if (loanApplication == null)
        {
            return NotFound();
        }
        return Ok(loanApplication);
    }

    [HttpPost]
    public ActionResult Create([FromBody] LoanApplicationFormDto loanApplicationDto)
    {
        var newLoanApplication = new LoanApplicationForm
        {
            ApplicationID = loanApplications.Count + 1,
            FullName = loanApplicationDto.FullName,
            DOB = loanApplicationDto.DOB,
            Email = loanApplicationDto.Email,
            Phone = loanApplicationDto.Phone,
            Address = loanApplicationDto.Address,
            City = loanApplicationDto.City,
            State = loanApplicationDto.State,
            ZipCode = loanApplicationDto.ZipCode,
            Income = loanApplicationDto.Income,
            EmploymentStatus = loanApplicationDto.EmploymentStatus,
            CreditScore = loanApplicationDto.CreditScore,
            Assets = loanApplicationDto.Assets,
            Loans = loanApplicationDto.Loans.Select(l => new LoanDetails
            {
                LoanID = 0, // Gerado automaticamente
                BankName = l.BankName,
                LoanAmount = l.LoanAmount,
                EMI = l.EMI
            }).ToList()
        };

        loanApplications.Add(newLoanApplication);

        return CreatedAtAction(nameof(GetById), new { id = newLoanApplication.ApplicationID }, newLoanApplication);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] LoanApplicationFormDto updatedLoanApplicationDto)
    {
        var loanApplication = loanApplications.FirstOrDefault(x => x.ApplicationID == id);
        if (loanApplication == null)
        {
            return NotFound();
        }

        loanApplication.FullName = updatedLoanApplicationDto.FullName;
        loanApplication.DOB = updatedLoanApplicationDto.DOB;
        loanApplication.Email = updatedLoanApplicationDto.Email;
        loanApplication.Phone = updatedLoanApplicationDto.Phone;
        loanApplication.Address = updatedLoanApplicationDto.Address;
        loanApplication.City = updatedLoanApplicationDto.City;
        loanApplication.State = updatedLoanApplicationDto.State;
        loanApplication.ZipCode = updatedLoanApplicationDto.ZipCode;
        loanApplication.Income = updatedLoanApplicationDto.Income;
        loanApplication.EmploymentStatus = updatedLoanApplicationDto.EmploymentStatus;
        loanApplication.CreditScore = updatedLoanApplicationDto.CreditScore;
        loanApplication.Assets = updatedLoanApplicationDto.Assets;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var loanApplication = loanApplications.FirstOrDefault(x => x.ApplicationID == id);
        if (loanApplication == null)
        {
            return NotFound();
        }

        loanApplications.Remove(loanApplication);

        return NoContent();
    }
}
}