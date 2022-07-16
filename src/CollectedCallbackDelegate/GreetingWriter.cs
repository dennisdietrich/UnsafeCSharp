namespace CollectedCallbackDelegate
{
    public class GreetingWriter
    {
        public string Name { get; }

        public GreetingWriter(string name) => Name = name;

        public void Greet() => Console.WriteLine($"Hello, {Name}!");
    }
}