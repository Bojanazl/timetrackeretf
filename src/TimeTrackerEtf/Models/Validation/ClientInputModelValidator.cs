using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackerEtf.Models.Validation
{
    public class ClientInputModelValidator : AbstractValidator<ClientModel>
    {
        public ClientInputModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 100);
        }
    }
}
