using api.Models;

namespace tests_api
{
    public class Tests
    {
        SourdoughStarterMix starterMix = new();

        [SetUp]
        public void Setup()
        {
            starterMix = new SourdoughStarterMix();
        }

        [Test]
        public void GetStarterMix_TemperatureConstants()
        {
            var tempC = starterMix.TemperatureC;
            var tempF = starterMix.TemperatureF();
            Assert.Multiple(() =>
            {
                Assert.That(tempC, Is.InstanceOf(typeof(double)));
                Assert.That(tempF, Is.EqualTo(starterMix.TemperatureC * 9 / 5 + 32));
            });
        }

        [Test]
        public void StarterMix_SetMassUnderZero_NoEffect()
        {
            var initialMass = starterMix.Mass;
            starterMix.Mass = -123;
            Assert.That(starterMix.Mass, Is.EqualTo(initialMass));
        }
    }
}