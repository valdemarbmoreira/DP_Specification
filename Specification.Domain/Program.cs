using Specification.Domain.Entities;
using Specification.Domain.Specifications;
using Specification.Domain.Specifications.Entities;
using Specification.Domain.Specifications.ValueObjects;
using Specification.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Specification.Domain
{
    class Program
    {
        static void Main(string[] args)
        {

            // Person list
            var people = new List<Person> {
                        new Person(Guid.NewGuid(), "Jacob 1", new Email("jacob1@gmail.com"), new Category(2, "Partner")),
                        new Person(Guid.NewGuid(), "Jacob 2", new Email("jacob2@gmail.com"), new Category(1, "Customer")),
                        new Person(Guid.NewGuid(), "Jacob 3", new Email("jacob3@gmail.com"), new Category(2, "Partner")),
                        new Person(Guid.NewGuid(), "Jacob 4", new Email("jacob4_gmail.com"), new Category(1, "Customer")),
                        new Person(Guid.NewGuid(), "Jacob 5", new Email("jacob5@gmail.com"), new Category(1, "Customer")),
                        new Person(Guid.NewGuid(), "Jacob 6", new Email("jacob6@gmail.com"), new Category(1, "Customer")),
                        new Person(Guid.NewGuid(), "Jacob 7", new Email("jacob7@gmail.com"), null) };

            Console.WriteLine(":: ALL PEOPLE ::");

            foreach (var item in people)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: CUSTOMER ::");

            ISpecification<Person> personCustomersSpecification = new PersonCustomerSpecification<Person>();

            var customer = people.FindAll(x => personCustomersSpecification.IsSatisfiedBy(x));

            foreach (var item in customer)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: PARTNER ::");

            ISpecification<Person> partnerSpecification = new ExpressionSpecification<Person>(x => x.Category?.CategoryId == 2);

            var partners = people.FindAll(x => partnerSpecification.IsSatisfiedBy(x));

            foreach (var item in partners)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine(":: ALL VALID ::");

            ISpecification<Person> validSpecification = new PersonValidSpecification<Person>()
                .And(new ExpressionSpecification<Person>(x=> x.Name.Equals("Jacob 7")));

            var validPeople = people.Where(x => validSpecification.IsSatisfiedBy(x));

            foreach (var item in validPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            

            Console.ReadKey();
        }
    }
}
