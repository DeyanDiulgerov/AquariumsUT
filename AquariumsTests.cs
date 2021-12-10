namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Aqua", 4);
            fish = new Fish("Puffer");
        }

        [Test]
        public void WhenAquariumNameIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 4));
        }
        [Test]
        public void WhenAquariumCapacityIsNegative_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Ime", -4));
        }
        [Test]
        public void WhenAquariumIsFull_ShouldThrowException()
        {
            var aquarium = new Aquarium("ime", 3);
            aquarium.Add(new Fish("Puf"));
            aquarium.Add(new Fish("Ruf"));
            aquarium.Add(new Fish("Gof"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Goshi")));
        }
        [Test]
        public void RemoveShouldWorkProperly()
        {
            var aquarium = new Aquarium("ime", 2);
            aquarium.Add(new Fish("fish1"));
            aquarium.Add(new Fish("fish2"));
            aquarium.RemoveFish("fish2");
            Assert.AreEqual(1, aquarium.Count);
            aquarium.RemoveFish("fish1");
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void WhenFishIsRemoved_ShouldThrowException()
        {
            var aquarium = new Aquarium("ime", 2);
            var fish = new Fish("Goshi");

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Toshi"));
        }
        [Test]
        public void WorkShouldThrowAnExceptionWhenFishIsNotFound()
        {
            var aquarium = new Aquarium("ime", 2);
            aquarium.Add(new Fish("Goshi"));
            Assert.Throws<InvalidOperationException>(
                () => aquarium.SellFish("Toshi"));
        }
        [Test]
        public void SellShouldWorkCorrectly()
        {
            var aquarium = new Aquarium("Name", 2);
            var fish = new Fish("Goshi");
            aquarium.Add(fish);
            aquarium.SellFish("Goshi");
        }
        [Test]
        public void SellShouldThrowException()
        {
            var aquarium = new Aquarium("Name", 2);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }
        [Test]
        public void Report()
        {
            var aquarium = new Aquarium("Name", 1);
            aquarium.Add(new Fish("Goshi"));

            string expectedMessage = $"Fish available at {"Name"}: {"Goshi"}";
            Assert.AreEqual(expectedMessage, aquarium.Report());

        }


    }
}
