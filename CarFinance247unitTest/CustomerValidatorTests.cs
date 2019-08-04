using System.Linq;
using System;
using CarFinance247TechTest.Domain;
using Xunit;

namespace CarFinance247unitTest
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void ShouldValidateValidCustomer()
        {
            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "Bobby", EMail = "bob@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldCatchIfIDIsEmpty()
        {


            var customer = new CreateCustomerRequest() { FirstName = "Bob", Surname = "Bobby", EMail = "bob@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal( "ID",result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ShouldCatchIfFirstNameIsEmpty()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "", Surname = "Bobby", EMail = "bob@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal("FirstName",result.Errors.FirstOrDefault().PropertyName );
        }

        [Fact]
        public void ShouldCatchIfFirstNameIsTooLong()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk", Surname = "Bobby", EMail = "bob@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal("FirstName",result.Errors.FirstOrDefault().PropertyName );
        }

        [Fact]
        public void ShouldCatchIfSurnameIsEmpty()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "", EMail = "bob@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal("Surname",result.Errors.FirstOrDefault().PropertyName );        }

        [Fact]
        public void ShouldCatchIfSurnameIsTooLong()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk", EMail = "bob@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal("Surname",result.Errors.FirstOrDefault().PropertyName );
        }

        [Fact]
        public void ShouldCatchIfEmailIsEmpty()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "bobby", EMail = "", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(2, result.Errors.Count());
            Assert.Equal("EMail",result.Errors.FirstOrDefault().PropertyName );
        }

        [Fact]
        public void ShouldCatchIfEMailIsTooLong()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "something", EMail = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk@bobby.com", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal("EMail",result.Errors.FirstOrDefault().PropertyName );
        }

        [Fact]
        public void ShouldCatchIfEMailIsNotAnEmail()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "something", EMail = "Random String", CustomerPassword = "password" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal("EMail",result.Errors.FirstOrDefault().PropertyName );
        }
          [Fact]
        public void ShouldCatchIfCustomerPasswordIsEmpty()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "bobby", EMail = "bob@bobby.com", CustomerPassword = "" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal( "CustomerPassword",result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ShouldCatchIfCustomerPasswordIsTooLong()
        {


            var customer = new CreateCustomerRequest() { ID = Guid.NewGuid(), FirstName = "Bob", Surname = "something", EMail = "bobby@bobby.com", CustomerPassword = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk" };
            var validator = new CreateCustomerValidator();

            var result = validator.Validate(customer);

            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count());
            Assert.Equal( "CustomerPassword",result.Errors.FirstOrDefault().PropertyName);
        }

        
    }
}