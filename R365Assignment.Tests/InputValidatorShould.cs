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
            var configuration = A.Fake<IConfiguration>();

            A.CallTo(() => configuration.MaxNumver).Returns(1000);

            _validator = new InputValidator(configuration);
        }

        [Fact]
        public void ReturnAllValidNumbers_WhenCalledWithNonNegativeNumbers()
        {
            var response = _validator.Validate(new decimal[] { 100, 0, 200, 4, (decimal)0.1, (decimal)1.1,1002, 15});
            response.Length.ShouldBe(8);

            response[0].ShouldBe(100);
            response[1].ShouldBe(0);
            response[2].ShouldBe(200);
            response[3].ShouldBe(4);
            response[4].ShouldBe((decimal)0.1);
            response[5].ShouldBe((decimal)1.1);
            response[6].ShouldBe(0);
            response[7].ShouldBe(15);
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
