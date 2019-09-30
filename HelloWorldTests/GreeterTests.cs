using HelloWorld;
using NUnit.Framework;

namespace HelloWorldTests
{
    // command line run: dotnet.exe test .\HelloWorldTests\HelloWorldTests.csproj
    [TestFixture]
    public class GreeterTests
    {
        [Test]
        public void ShouldGreetWithThePersonsNameIfTheNameIsProvided()
        {
            //Setup
            var greeter = new Greeter(); 

            //Act
            var greeting = greeter.Greet("John"); 
            
            //Assert
            Assert.That(greeting, Is.EqualTo("Hello John!")); 
        }

        [Test]
        public void ShouldBeAbleToGreetManyPeople()
        {
            //Setup
            var greeter = new Greeter(); 

            //Act
            var greeting = greeter.Greet("John", "Lisa", "Ravi"); 
            
            //Assert
            Assert.That(greeting, Is.EqualTo("Hello John, Lisa, and Ravi!")); 
        }
        
        [Test]
        public void ShouldGreetWithThePersonsNameIfTheNameIsNotProvided()
        {
            //Setup
            var greeter = new Greeter(); 

            //Act
            var greeting = greeter.Greet(); 
            
            //Assert
            Assert.That(greeting, Is.EqualTo("Hello World!")); 
        }
    }
}