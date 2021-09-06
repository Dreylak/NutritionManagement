using FluentValidation;
using System;

namespace Event.Logic.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(v => v.ShortDescription)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(v => v.FullDescription)
                .MaximumLength(500)
                .NotEmpty();

            RuleFor(v => v.Address)
                .NotEmpty();

            RuleFor(v => v.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Start date at least greater than or equal to current date.");

            RuleFor(v => v.EndDate)
                .GreaterThanOrEqualTo(v => v.StartDate).WithMessage("End date at least greater than or equal to start date.");

            RuleFor(v => v.CustomersCapacity)
                .GreaterThanOrEqualTo(1).WithMessage("Customers capacity at least greater than or equal to 1."); ;
        }
    }
}
