using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;


namespace Test.TestHelpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAutoDataAttribute : AutoDataAttribute
    {
        public CustomAutoDataAttribute() : base(CreateFixture)
        {
        }

        private static IFixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
           .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true, GenerateDelegates = true });

            return fixture;
        }
    }
}
