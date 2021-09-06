using FluentValidation;

namespace Event.Logic.Enrollments.Commands.RemoveCustomerFromEvent
{
    public class RemoveCustomerFromEventCommandValidator : AbstractValidator<RemoveCustomerFromEventCommand>
    {
        public RemoveCustomerFromEventCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThanOrEqualTo(1).WithMessage("Customer Id at least greater than or equal to 1.");

            RuleFor(x => x.EventId)
                .GreaterThanOrEqualTo(1).WithMessage("Event Id at least greater than or equal to 1.");
        }
    }
}
