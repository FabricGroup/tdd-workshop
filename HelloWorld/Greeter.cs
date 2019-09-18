namespace HelloWorld
{
    public class Greeter
    {
        public string Greet(params string[] names)
        {
            var peopleToGreet = names.Length == 0 ? "World" : string.Join(", ", names);
            return $"Hello {peopleToGreet}!";
        }
    }
}