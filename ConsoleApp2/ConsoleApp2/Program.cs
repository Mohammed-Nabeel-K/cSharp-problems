using System;

namespace Project2
{
    using System;

    class Animal
    {
        public string Name { get; set; }  
        public int Age { get; set; }    

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Speak()
        {
            Console.WriteLine($"{Name} is {Age} years old.");
        }
    }

    class Dog : Animal
    {
        public string Breed { get; set; }  

        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }
    }

    class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age) { }

        public void Meow()
        {
            Console.WriteLine("Meow!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Buddy", 3, "Golden Retriever");
            Cat cat = new Cat("Whiskers", 2);

            dog.Speak();  
            cat.Speak();  

            cat.Meow();

            string s = Console.ReadLine();
        }
    }
}