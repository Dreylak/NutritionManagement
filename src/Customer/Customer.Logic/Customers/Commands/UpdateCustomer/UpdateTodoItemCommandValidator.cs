using FluentValidation;

namespace Customer.Logic.Customers.Commands.UpdateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
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
