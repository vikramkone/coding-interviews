using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact { Name = "A", Phone = "P1", Email = "E1" },
                new Contact { Name = "B", Phone = "P2", Email = "E2" },
                new Contact { Name = "C", Phone = "P2", Email = "E1" },
                new Contact { Name = "D", Phone = "P1", Email = "E2" },
                new Contact { Name = "E", Phone = "P3", Email = "E3" },
                new Contact { Name = "E", Phone = "P4", Email = "E4" },
                new Contact { Name = "F", Phone = "P5", Email = "E5" },
                new Contact { Name = "G", Phone = "P6", Email = "E6" },
            };

            DuplicateContacts sol = new DuplicateContacts(contacts);
            sol.Run();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
