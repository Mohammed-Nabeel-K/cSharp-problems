using System;

namespace Project2
{
    class Animal
    {
        public string name {  get; set; }
        public int age {  get; set; }
        public void Speak()
        {
            Console.WriteLine($"this is a {this.name} with age of {this.age}");
        }
    }
    class Dog : Animal {
        string name = "dog";
        int age = 3;
        public string breed = "something";
    }
    class Cat : Animal {
        public string name = "cat";
        public int age = 5;
        
         public void Speak() {
            Console.WriteLine($"it is a {name} and age = {age}");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Animal animal = new Animal();
            Cat cat = new Cat();
            Dog dog = new Dog();

            animal.Speak();
            dog.Speak();
            cat.Speak();
            
        }
    }
}