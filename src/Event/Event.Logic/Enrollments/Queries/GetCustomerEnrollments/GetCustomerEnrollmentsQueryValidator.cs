using FluentValidation;

namespace Event.Logic.Enrollments.Queries.GetCustomerEnrollments
{
    public class GetCustomerEnrollmentsQueryValidator : AbstractValidator<GetCustomerEnrollmentsQuery>
    {
        public GetCustomerEnrollmentsQueryValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThanOrEqualTo(1).WithMessage("Customer Id at least greater than or equal to 1.");
        }
    }
}
