using System;

namespace AssignmentTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Tuples

            var employees = (SE: "Sam", BA: "Pam");
            Console.WriteLine($"{employees.SE}, {employees.BA}");

            (string name, int age) info = ("sam", 21);
            Console.WriteLine($"{info.name},{info.age}"); 


            //Pattern Matching
            string checkNull = null;
            var objPerson = new Person() { firstName = "Kajal", lastName = "Padhiyar", age = 33 };
            var myData = "My Custom Data";

            //Is pattern
            var myData2 = myData is string p ? $"{p} is a string" : "Not a String";
            var myData3 = checkNull is null ? "It is a Null value string" : "Not Null";
            if (objPerson is Person person)
                Console.WriteLine($"person is of type {person.GetType().Name} and first name is {person.firstName}");
            Console.WriteLine(myData2);
            Console.WriteLine(myData3);


            //Case pattern
            switch (objPerson)
            {
                case Person person1 when (person1.age == 33):
                    Console.WriteLine($"Person {person1.firstName}");
                    break;
                case Person person1 when (person1.age > 33):
                    Console.WriteLine($"Reader {person1.firstName}");
                    break;
                default:
                    Console.WriteLine("Not found");
                    break;
            }
            int i = 5;
            switch (i)
            {
                case int k:
                    Console.WriteLine($"{k} it's an integer");
                    break;
                default:
                    throw new InvalidOperationException("Unrecognized type");
            }

            //Since a is null it will throw null exception
            /*Person a = null;
            switch (a)
            {
                case Person person1 when (person1.age >= 33):
                    Console.WriteLine($"Person {person1.firstName}");
                    break;
                default:
                    Console.WriteLine("Not found");
                    break;
                case null:
                    throw new NullReferenceException("Null found in sequence");
            }*/
        }
    }
}
