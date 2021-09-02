using FluentValidation;

namespace Customer.Logic.Customers.Queries.GetCustomerDetailsById
{
    public class GetCustomerDetailsByIdQueryValidator : AbstractValidator<GetCustomerDetailsByIdQuery>
    {
        public GetCustomerDetailsByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1).WithMessage("Id at least greater than or equal to 1.");
        }
    }
}
