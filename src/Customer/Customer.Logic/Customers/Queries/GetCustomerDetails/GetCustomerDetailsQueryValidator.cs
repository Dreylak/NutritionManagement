using FluentValidation;

namespace Customer.Logic.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryValidator : AbstractValidator<GetCustomerDetailsQuery>
    {
        public GetCustomerDetailsQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id at least greater than or equal to 1.");
        }
    }
}
