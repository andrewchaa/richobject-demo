using System;
using RichObject.Domain.Commands;

namespace RichObject.Domain.Values
{
    public class Dob
    {
        public DateTime DateOfBirth { get; }
        public int Age { get; }

        private Dob(DateTime dateOfBirth)
        {
            var age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;

            DateOfBirth = dateOfBirth;
            Age = age;
        }


        public static OperationResult<Dob> Create(DateTime dateOfBirth)
        {
            var dob = new Dob(dateOfBirth);
            if (dob.Age < 18)
                return OperationResult<Dob>.ValidationFailure(new [] {"The applicant's age must be at least 18"});

            return OperationResult<Dob>.Success(new Dob(dateOfBirth));
        }
    }
}