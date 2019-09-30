using HelloWorld;
using Moq;
using NUnit.Framework;

namespace HelloWorldTests
{
    // command line run: dotnet.exe test .\HelloWorldTests\HelloWorldTests.csproj
    [TestFixture]
    public class GreeterTests
    {
        private Greeter _greeter;
        private Mock<ISend> _mockSender;

        [SetUp]
        public void SetUp()
        {
            _mockSender = new Mock<ISend>();
            _greeter = new Greeter(_mockSender.Object);
        }

        [TestCase(new[] {"John"}, "Hello John!")]
        [TestCase(new[] {"John", "Lisa", "Ravi"}, "Hello John, Lisa, and Ravi!")]
        [TestCase(new string[0], "Hello World!")]
        [TestCase(null, "Hello World!")]
        public void ShouldGenerateTheCorrectGreeting(string[] names, string expectedGreeting)
        {
            //Act
            var greeting = _greeter.Greet(names);

            //Assert
            Assert.That(greeting, Is.EqualTo(expectedGreeting));
        }


        [TestCase(new[] {"John"}, "Hello John!")]
        [TestCase(new[] {"John", "Lisa", "Ravi"}, "Hello John, Lisa, and Ravi!")]
        [TestCase(new string[0], "Hello World!")]
        [TestCase(null, "Hello World!")]
        public void ShouldSendTheGreeting(string[] names, string expectedGreeting)
        {
            //Act
            _greeter.SendGreeting(names);

            //Assert
            _mockSender.Verify(x => x.Send(expectedGreeting));
        }
    }
}