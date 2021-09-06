using FluentValidation;

namespace Customer.Logic.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id at least greater than or equal to 1.");

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
