using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private List<Person> persons;

        public Repository()
        {
            this.persons = new List<Person>();
        }

        public int Count => persons.Count;

        public void Add(Person person)
        {
            persons.Add(person);
        }
        public Person Get(int id)
        {
            Person pesho = persons[id];
            return pesho;
        }

        public bool Update(int id, Person newPerson)
        {
            if (persons.Count > id)
            {
                persons[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (persons.Count > id)
            {
                persons.RemoveAt(id);
                return true;
            }
            return false;
        }
    }
}
