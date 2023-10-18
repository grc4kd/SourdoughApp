using webapi.models;

namespace tests_api
{
    public class Tests
    {
        [Test]
        public void GetStarterMix_TemperatureConstants()
        {
            var starterMix = new SourdoughStarterMix();

            const double expectedTempC = 20f;
            const double expectedTempF = 68f;

            starterMix.TemperatureC = expectedTempC;

            var tempF = starterMix.TemperatureF();

            Assert.Multiple(() =>
            {
                Assert.That(starterMix.TemperatureF(), Is.InstanceOf<double>());
                Assert.That(starterMix.TemperatureF(), Is.EqualTo(expectedTempF));

                Assert.That(starterMix.TemperatureC, Is.InstanceOf<double>());
                Assert.That(starterMix.TemperatureC, Is.EqualTo(expectedTempC));
            });
        }

        [Test]
        public void StarterMix_SetMassUnderZero_NoEffect()
        {
            var expectedMass = 250;
            var starterMix = new SourdoughStarterMix
            {
                Mass = expectedMass
            };

            starterMix.Mass = -123;

            Assert.That(starterMix.Mass, Is.EqualTo(expectedMass));
        }
    }
}