using System;

namespace linq1
{
    public class PersonDetails
    {
        public string Name { get; set; }
        public int Age {  get; set; }
        public string City { get; set; }

        public PersonDetails(string name, int age, string city) {
            Name = name;
            Age = age;
            City = city;
        }
        
    }

    class Program
    {
        public static void Main(string[] args)
        {
            List<PersonDetails> list = new List<PersonDetails>();

            list.Add(new PersonDetails("Nabeel", 23, "kizhishery"));
            list.Add(new PersonDetails("Ajfar", 25, "kondotty"));
            list.Add(new PersonDetails("Adarsh", 26, "kozhikkode"));
            list.Add(new PersonDetails("Ameen", 28, "valanchery"));
            list.Add(new PersonDetails("Ainas", 29, "thurakkal"));

            var AboveAge = list.Where(n => n.Age > 25 && n.City == "thurakkal");
            var NameandAge = AboveAge.Select(n => new { n.Name, n.Age });
            Console.WriteLine("persons with age greaterthan 25 and live in thurakkal");
            foreach (var a in NameandAge) {
                Console.WriteLine($"name = {a.Name} and age = {a.Age} " );
            }


        }
    }
}