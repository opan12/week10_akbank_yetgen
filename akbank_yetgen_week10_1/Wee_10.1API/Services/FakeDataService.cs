﻿using Bogus;
using Week_10_1.Domain.Entities;
using Week_10_1.Persistence.Context;

namespace Wee_10._1API.Services
{
   
        public class FakeDataService
        {
            private readonly ApplicationDbContext _applicationDbContext;
            private readonly Random _random;

            public FakeDataService(ApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;

                _random = new Random();
            }


            public async Task<int> GenerateStudentDataAsync(CancellationToken cancellationToken)
            {
                var fakeStudentRules = new Faker<Student>("tr")
                    .RuleFor(s => s.Id, new Guid())
                    .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                    .RuleFor(s => s.LastName, f => f.Name.LastName())
                    .RuleFor(s => s.Country, f => f.Address.Country())
                    .RuleFor(s => s.City, f => f.Address.City())
                    .RuleFor(s => s.Company, f => f.Company.CompanyName())
                    .RuleFor(s => s.Age, f => Convert.ToInt16(_random.Next(10, 59)))
                    .RuleFor(s => s.RegistrationFee, f => _random.Next(0, 9999))
                    .RuleFor(s => s.CreatedOn, f => DateTimeOffset.UtcNow)
                    .RuleFor(s => s.CreatedByUserId, f => "sudeopan");

                var students = fakeStudentRules.Generate(10000);

                foreach (var student in students)
                    student.Id = Guid.NewGuid();


                await _applicationDbContext.Students.AddRangeAsync(students, cancellationToken);

                var recordCount = await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return recordCount;
            }
        }
    }

