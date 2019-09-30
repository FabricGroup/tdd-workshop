using System.Linq;

namespace HelloWorld
{
    public class Greeter
    {
        public string Greet(params string[] names)
        {
            var peopleToGreet = names.Length == 0 ? "World" : PeopleToGreet(names);
            return $"Hello {peopleToGreet}!";
        }

        private static string PeopleToGreet(string[] names)
        {
            if (names.Length == 1) return names[0];
            return $"{string.Join(", ", names.Take(names.Length - 1))}, and {names.Last()}";
        }
    }
}