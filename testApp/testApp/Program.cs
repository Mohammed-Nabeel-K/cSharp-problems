using System;

namespace Project
{
    class List1
    {

        class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
        public static void Main(string[] args)
        {
            //List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var OddNumbers = list.Where(num => num % 2 != 0);
            //foreach (int num in OddNumbers)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.WriteLine($"Largest number = {list.Max()}");

            List<Person> list = new List<Person>
            {
                new Person("nabeel",23),
                new Person("ainas",23),
                new Person("ajfar",24),
                new Person("ameen",25)
            };
            
            var Average = list.Average(n => n.Age);
            var highAge = list.Max(n => n.Age);
            Console.WriteLine(highAge);
            Console.WriteLine(Average);

            var AboveAverage = list.Where(n => n.Age > Average);
            foreach (var person in AboveAverage)
            {
                Console.WriteLine(person.Name);
            }
        }


    }
}