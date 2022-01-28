using PrototypePatternSample;
using System.Text.Json;

Console.WriteLine("Hello, Prototype Pattern :D");

Console.WriteLine();
var person = new Person("Nima", "Airyana");
Console.WriteLine("person is = " + person.ToString());

Console.WriteLine();
var wrongClonedPerson = person;
wrongClonedPerson.FirstName = "Github";
Console.WriteLine("wrongClonedPerson is = " + wrongClonedPerson.ToString());
Console.WriteLine("This is wrong because the person changed!");
Console.WriteLine("person is = " + person.ToString());

Console.WriteLine();
var correctClonedPerson = person.GetPrototype(); // We used prototype extension method :D
correctClonedPerson.FirstName = "Change To Nima";
Console.WriteLine("correctClonedPerson is = " + correctClonedPerson.ToString());
Console.WriteLine("This is correct because the person not changed ^_^");
Console.WriteLine("And at last person is = " + person.ToString());

namespace PrototypePatternSample
{
    public interface IPrototype { }

    public static class PrototypeExtension
    {
        public static TPrototype GetPrototype<TPrototype>(this TPrototype instance) where TPrototype : IPrototype
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            var instanceSerialized = JsonSerializer.Serialize(instance);

            return JsonSerializer.Deserialize<TPrototype>(instanceSerialized);
        }
    }

    public class Person : IPrototype
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
