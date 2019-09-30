using System;
using System.Linq;

namespace HelloWorld
{
    public class Greeter
    {
        private readonly ISend _sender;
        private readonly DateTimeWrapper _dateTimeWrapper;

        public Greeter(ISend sender, DateTimeWrapper dateTimeWrapper)
        {
            _sender = sender;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public string Greet(params string[] names)
        {
            var peopleToGreet = names?.Length > 0 ? PeopleToGreet(names) : "World";
            return $"Hello {peopleToGreet}!";
        }

        private static string PeopleToGreet(string[] names)
        {
            if (names.Length == 1) return names[0];
            return $"{string.Join(", ", names.Take(names.Length - 1))}, and {names.Last()}";
        }

        public void SendGreeting(string[] names, DateTime? dateToSend = null)
        {
            _sender.Send(Greet(names), dateToSend ?? _dateTimeWrapper.Now);
        }
    }
}