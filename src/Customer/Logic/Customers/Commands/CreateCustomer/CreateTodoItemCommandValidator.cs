using FluentValidation;

namespace Customer.Logic.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(v => v.LastName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(v => v.BirthDate)
                .NotEmpty();
        }
    }
}
