using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }

        public Person(int id, string name, string lastName, string mail)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Mail = mail;
        }
    }
}
