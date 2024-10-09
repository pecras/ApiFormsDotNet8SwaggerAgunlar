using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ApiForms.Models;

namespace ApiForms.Tests
{
    public class LoanApplicationFormTestsModels
    {
        [Fact]
        public void LoanApplicationForm_ShouldInitializeCorrectly()
        {
            // Arrange
            var loanApplication = new LoanApplicationForm
            {
                ApplicationID = 1,
                FullName = "John Doe",
                DOB = new DateTime(1985, 1, 1),
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Address = "123 Main St",
                City = "Springfield",
                State = "IL",
                ZipCode = "62701",
                Income = 50000,
                EmploymentStatus = "Employed",
                CreditScore = 700,
                Assets = "House, Car",
                Loans = new List<LoanDetails>()
            };

            // Assert
            Assert.Equal(1, loanApplication.ApplicationID);
            Assert.Equal("John Doe", loanApplication.FullName);
            Assert.Equal(new DateTime(1985, 1, 1), loanApplication.DOB);
            Assert.Equal("john.doe@example.com", loanApplication.Email);
            Assert.Equal("1234567890", loanApplication.Phone);
            Assert.Equal("123 Main St", loanApplication.Address);
            Assert.Equal("Springfield", loanApplication.City);
            Assert.Equal("IL", loanApplication.State);
            Assert.Equal("62701", loanApplication.ZipCode);
            Assert.Equal(50000, loanApplication.Income);
            Assert.Equal("Employed", loanApplication.EmploymentStatus);
            Assert.Equal(700, loanApplication.CreditScore);
            Assert.Equal("House, Car", loanApplication.Assets);
        }
    }
}