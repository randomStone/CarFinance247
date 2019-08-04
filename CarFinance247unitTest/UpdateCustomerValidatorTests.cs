using System;
using System.Linq;
using CarFinance247TechTest.Domain;
using Xunit;

public class UpdateCustomerValidatorTests
{
    [Fact]
    public void ShouldCatchIfFirstNameIsEmpty()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "", Surname = "Bobby", EMail = "bob@bobby.com", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("FirstName", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfFirstNameIsTooLong()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk", Surname = "Bobby", EMail = "bob@bobby.com", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("FirstName", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfSurnameIsEmpty()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "", EMail = "bob@bobby.com", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("Surname", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfSurnameIsTooLong()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk", EMail = "bob@bobby.com", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("Surname", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfEmailIsEmpty()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "bobby", EMail = "", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(2, result.Errors.Count());
        Assert.Equal("EMail", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfEMailIsTooLong()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "something", EMail = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk@bobby.com", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("EMail", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfEMailIsNotAnEmail()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "something", EMail = "Random String", CustomerPassword = "password" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("EMail", result.Errors.FirstOrDefault().PropertyName);
    }
    [Fact]
    public void ShouldCatchIfCustomerPasswordIsEmpty()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "bobby", EMail = "bob@bobby.com", CustomerPassword = "" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("CustomerPassword", result.Errors.FirstOrDefault().PropertyName);
    }

    [Fact]
    public void ShouldCatchIfCustomerPasswordIsTooLong()
    {


        var customer = new UpdateCustomerRequest() { FirstName = "Bob", Surname = "something", EMail = "bobby@bobby.com", CustomerPassword = "abcdefghijkmlpqjfkidsjfkdsjfkdsjfkdsjfkdsjfkdsjfkdsjfdksjfdskfjdskfdjkfdsjkfdsjdsfkjfdskjfdskfdjkfdsjfdksjfdskjfdskfdjkdfjkdfsjdfsk" };
        var validator = new UpdateCustomerValidator();

        var result = validator.Validate(customer);

        Assert.False(result.IsValid);
        Assert.Equal(1, result.Errors.Count());
        Assert.Equal("CustomerPassword", result.Errors.FirstOrDefault().PropertyName);
    }
}