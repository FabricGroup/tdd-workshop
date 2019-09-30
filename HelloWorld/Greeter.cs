using System.Linq;

namespace HelloWorld
{
    public class Greeter
    {
        private readonly ISend _sender;

        public Greeter(ISend sender)
        {
            _sender = sender;
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

        public void SendGreeting(params string[] names)
        {
            _sender.Send(Greet(names));
        }
    }
}