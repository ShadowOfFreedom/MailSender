using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonList
{
    public class PersonsList
    {
        public static List<Person> Persons = new List<Person>
        {
            new Person(1, "Roman", "Kowalski", "roman.kowalski@wwp.pl"),
            new Person(2,"Krzysztof", "Kowalski", "krzysztof.kowalski@fmail.pl"),
            new Person(3,"Anna", "Jowalska", "a.jowa@aw.org"),
            new Person(4,"Zbyszek", "Kowalski", "zbychu.kowalski@wpp.pl"),
            new Person(5,"Roman", "Zakrz", "rzakrz@mom.com")
        };
    }
}
