
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ApiForms.Controllers;
using ApiForms.DTOS;
using ApiForms.Models;

using System.Collections.Generic;

namespace ApiForms.Tests
{
    public class LoanApplicationFormsControllerTests
    {
        private readonly LoanApplicationFormsController _controller;

        public LoanApplicationFormsControllerTests()
        {
            // Iniciar o controlador
            _controller = new LoanApplicationFormsController();
        }

        [Fact]
        public void GetAll_ShouldReturnAllLoanApplications()
        {
            // Arrange
            _controller.Create(new LoanApplicationFormDto
            {
                FullName = "John Doe",
                DOB =  DateTime.Parse("1985-05-05"),
                Email = "john@example.com",
                Phone = "1234567890",
                Address = "123 Main St",
                City = "Anytown",
                State = "CA",
                ZipCode = "12345",
                Income = 50000,
                EmploymentStatus = "Employed",
                CreditScore = 700,
                Assets = "Car",
                Loans = new List<LoanDetailsDto>()
            });

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var loanApplications = Assert.IsAssignableFrom<List<LoanApplicationForm>>(okResult.Value);
            Assert.Equal(1, loanApplications.Count);
        }

        [Fact]
        public void GetById_ExistingId_ShouldReturnLoanApplication()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationFormDto
            {
                FullName = "Jane Doe",
                DOB =  DateTime.Parse("1985-05-05"),
                Email = "jane@example.com",
                Phone = "0987654321",
                Address = "456 Elm St",
                City = "Othertown",
                State = "TX",
                ZipCode = "67890",
                Income = 60000,
                EmploymentStatus = "Unemployed",
                CreditScore = 650,
                Assets = "None",
                Loans = new List<LoanDetailsDto>()
            };
            _controller.Create(loanApplicationDto);

            // Act
            var result = _controller.GetById(2);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var loanApplication = Assert.IsType<LoanApplicationForm>(okResult.Value);
            Assert.Equal(2, loanApplication.ApplicationID);
            Assert.Equal("Jane Doe", loanApplication.FullName);
        }

        [Fact]
        public void Create_ShouldAddLoanApplication()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationFormDto
            {
                FullName = "Alice Smith",
                DOB = DateTime.Parse("1985-05-05"),
                Email = "alice@example.com",
                Phone = "3216549870",
                Address = "789 Maple Ave",
                City = "Somewhere",
                State = "NY",
                ZipCode = "54321",
                Income = 75000,
                EmploymentStatus = "SelfEmployed",
                CreditScore = 720,
                Assets = "House",
                Loans = new List<LoanDetailsDto>()
            };

            // Act
            var result = _controller.Create(loanApplicationDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var loanApplication = Assert.IsType<LoanApplicationForm>(createdResult.Value);
            Assert.Equal(1, loanApplication.ApplicationID); // O ID deve ser 1 pois é o primeiro
        }

        [Fact]
        public void Update_ExistingId_ShouldUpdateLoanApplication()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationFormDto
            {
                FullName = "Bob Brown",
                DOB =  DateTime.Parse("1985-05-05"),
                Email = "bob@example.com",
                Phone = "9876543210",
                Address = "159 Oak St",
                City = "Elsewhere",
                State = "FL",
                ZipCode = "13579",
                Income = 80000,
                EmploymentStatus = "Employed",
                CreditScore = 690,
                Assets = "Car",
                Loans = new List<LoanDetailsDto>()
            };
            _controller.Create(loanApplicationDto);

            var updatedLoanApplicationDto = new LoanApplicationFormDto
            {
                FullName = "Robert Brown",
                DOB =  DateTime.Parse("1985-05-05"),
                Email = "robert@example.com",
                Phone = "9876543210",
                Address = "159 Oak St",
                City = "Elsewhere",
                State = "FL",
                ZipCode = "13579",
                Income = 85000,
                EmploymentStatus = "Employed",
                CreditScore = 710,
                Assets = "Car",
                Loans = new List<LoanDetailsDto>()
            };

            // Act
            var result = _controller.Update(1, updatedLoanApplicationDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var loanApplication = _controller.GetById(1);
            var okResult = Assert.IsType<OkObjectResult>(loanApplication.Result);
            var updatedApplication = Assert.IsType<LoanApplicationForm>(okResult.Value);
            Assert.Equal("Robert Brown", updatedApplication.FullName);
        }

        [Fact]
        public void Delete_ExistingId_ShouldRemoveLoanApplication()
        {
            // Arrange
            var loanApplicationDto = new LoanApplicationFormDto
            {
                FullName = "Charlie Davis",
                DOB = DateTime.Parse("1985-05-05"),
                Email = "charlie@example.com",
                Phone = "6543219870",
                Address = "246 Pine St",
                City = "Anywhere",
                State = "NV",
                ZipCode = "24680",
                Income = 90000,
                EmploymentStatus = "Unemployed",
                CreditScore = 600,
                Assets = "None",
                Loans = new List<LoanDetailsDto>()
            };
            _controller.Create(loanApplicationDto);

            // Act
            var result = _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var loanApplication = _controller.GetById(1);
            Assert.IsType<NotFoundResult>(loanApplication.Result);
        }
    }
}
