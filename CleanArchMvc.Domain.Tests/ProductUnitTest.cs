using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Xuxa", "Bla bla bla", 10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateCategory_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Xuxa", "Bla bla bla", 10, 100, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Xuxa", "Bla bla bla", 10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateCategory_EmptyNameValue_DomainExceptionEmptyName()
        {
            Action action = () => new Product(1, "", "Bla bla bla", 10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "ab", "Bla bla bla", 10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateCategory_EmptyDescriptionValue_DomainExceptionEmptyName()
        {
            Action action = () => new Product(1, "Xuxa", "", 10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description is required");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateCategory_ShortDescriptionValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Xuxa", "Abc", 10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateCategory_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Xuxa", "Bla bla bla", -10, 100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateCategory_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Xuxa", "Bla bla bla", 10, -100, "htttp://xuxa-png.com.br");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Long Image")]
        public void CreateCategory_LongImageValue_DomainExceptionLongImage()
        {
            Action action = () => new Product(1, "Xuxa", "Bla bla bla", 10, 100, "htttp://xuxa-png.com.br toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooonooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }
    }
}
