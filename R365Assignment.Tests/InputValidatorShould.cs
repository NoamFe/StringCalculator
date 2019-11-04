using Xunit;
using Shouldly;
using FakeItEasy;
using System;

namespace R365Assignment.Tests
{
    public class InputValidatorShould
    {
        IInputValidator _validator;
        public InputValidatorShould()
        {
            _validator = new InputValidator();
        }

        [Fact]
        public void ReturnTrue_WhenCalledWithNonNegativeNumbers()
        {
            var response = _validator.Validate(new decimal[] { 100, 0, 200, 4, (decimal)0.1, (decimal)1.1, 15});
            response.ShouldBeTrue();
        }


        [Fact]
        public void ThrowException_WhenValidateNegativeNumbers()
        {
            Exception exception = Should.Throw<ArgumentException>(() =>
                 _validator.Validate(new decimal[] { -5, (decimal)-0.8, 10, 22, 5, -19, 4 }));
 
            exception.Message.ShouldBe(@"negative numbers are not allowed: -5,-0.8,-19");           
        }
    }
}
