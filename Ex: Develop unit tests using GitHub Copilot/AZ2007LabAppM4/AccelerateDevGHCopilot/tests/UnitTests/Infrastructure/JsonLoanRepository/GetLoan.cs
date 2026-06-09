using System;
using System.Collections.Generic;
using NSubstitute;
using Xunit;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
    
 namespace UnitTests.Infrastructure.JsonLoanRepositoryTests;
    
 public class GetLoanTest
 {
     private readonly ILoanRepository _mockLoanRepository;
     private readonly JsonLoanRepository _jsonLoanRepository;
     private readonly IConfiguration _configuration;
     private readonly JsonData _jsonData;
    
     public GetLoanTest()
     {
         _mockLoanRepository = Substitute.For<ILoanRepository>();
         _configuration = new ConfigurationBuilder().Build();
         _jsonData = new JsonData(_configuration);
         _jsonLoanRepository = new JsonLoanRepository(_jsonData);
     }
    
    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when id exists")]
    public async Task GetLoan_ReturnsLoan_WhenIdExists()
    {
        // Arrange
        var loanId = 1; // exists in src/Library.Console/Json/Loans.json

        var expectedLoan = new Library.ApplicationCore.Entities.Loan
        {
            Id = loanId,
            BookItemId = 17,
            PatronId = 22,
            LoanDate = DateTime.Now.AddDays(-10),
            DueDate = DateTime.Now.AddDays(4),
            ReturnDate = null
        };

        // arrange mock for reference (not used by JsonLoanRepository but per test requirements)
        _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

        // populate in-memory JsonData so EnsureDataLoaded does not try to read files
        _jsonData.Loans = new List<Library.ApplicationCore.Entities.Loan> { new Library.ApplicationCore.Entities.Loan { Id = loanId, BookItemId = 17, PatronId = 22, LoanDate = expectedLoan.LoanDate, DueDate = expectedLoan.DueDate, ReturnDate = expectedLoan.ReturnDate } };
        _jsonData.Patrons = new List<Library.ApplicationCore.Entities.Patron> { new Library.ApplicationCore.Entities.Patron { Id = 22, Name = "Test Patron", MembershipEnd = DateTime.Now.AddDays(30), Loans = new List<Library.ApplicationCore.Entities.Loan>() } };

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.NotNull(actualLoan);
        Assert.Equal(expectedLoan.Id, actualLoan!.Id);
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when id does not exist")]
    public async Task GetLoan_ReturnsNull_WhenIdDoesNotExist()
    {     
        // Arrange
         var loanId = 999; // Loan ID that does not exist in Loans.json

         _mockLoanRepository.GetLoan(loanId).Returns((Loan?)null);

         // Act
         var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

         // Assert
         Assert.Null(actualLoan);
    }

 }