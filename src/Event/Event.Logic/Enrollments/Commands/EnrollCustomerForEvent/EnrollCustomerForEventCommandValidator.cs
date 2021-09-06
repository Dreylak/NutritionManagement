using FluentValidation;

namespace Event.Logic.Enrollments.Commands.EnrollCustomerForEvent
{
    public class EnrollCustomerForEventCommandValidator : AbstractValidator<EnrollCustomerForEventCommand>
    {
        public EnrollCustomerForEventCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThanOrEqualTo(1).WithMessage("Customer Id at least greater than or equal to 1.");

            RuleFor(x => x.EventId)
                .GreaterThanOrEqualTo(1).WithMessage("Event Id at least greater than or equal to 1.");
        }
    }
}
