using FluentValidation;
namespace CarFinance247TechTest.Domain
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(customer => customer.ID).NotEmpty();
            RuleFor(customer => customer.FirstName).NotEmpty().MaximumLength(64);
            RuleFor(customer => customer.Surname).NotEmpty().MaximumLength(64);
            RuleFor(customer => customer.EMail).NotEmpty().MaximumLength(64).EmailAddress();
            RuleFor(customer => customer.CustomerPassword).NotEmpty().MaximumLength(64);

        }
    }
}