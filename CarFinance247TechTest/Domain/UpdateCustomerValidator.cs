using FluentValidation;
namespace CarFinance247TechTest.Domain
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().MaximumLength(64);
            RuleFor(customer => customer.Surname).NotEmpty().MaximumLength(64);
            RuleFor(customer => customer.EMail).NotEmpty().MaximumLength(64).EmailAddress();
            RuleFor(customer => customer.CustomerPassword).NotEmpty().MaximumLength(64);

        }
    }
}