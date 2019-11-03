using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Text;

namespace R365Assignment.Tests
{
    public class AutoFillAttribute : AutoDataAttribute
    {
        public AutoFillAttribute() : base(() => new Fixture().Customize(new DomainCustomization()))
        {
        }

        private class DomainCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            { 
                fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            }
        }
    }
}
