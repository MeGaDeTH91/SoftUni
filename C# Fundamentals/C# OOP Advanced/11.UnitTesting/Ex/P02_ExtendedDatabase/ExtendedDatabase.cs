namespace P02_ExtendedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendedDatabase
    {
        private const int Initial_Capacity = 16;

        private Person[] people;
        private HashSet<long> Ids;
        private HashSet<string> Names;

        public IReadOnlyCollection<Person> DatabasePeople { get { return this.people.Take(this.Count).ToList().AsReadOnly(); } }

        public int Count { get; private set; }

        public ExtendedDatabase(params Person[] people)
        {
            this.people = new Person[Initial_Capacity];            
            this.Ids = new HashSet<long>();
            this.Names = new HashSet<string>();
            this.InitializeArray(people);
        }

        public Person FindByUsername(string username)
        {
            this.ValidateUsername(username);
            this.ValidateIfSuchUsernameIsPresent(username);

            Person person = this.people.FirstOrDefault(x => x.Username == username);

            return person;
        }

        public Person FindById(long id)
        {
            this.ValidateId(id);
            this.ValidateIfSuchUserIdIsPresent(id);

            Person person = this.people.FirstOrDefault(x => x.Id == id);

            return person;
        }

        public void Add(Person person)
        {
            if(this.Count + 1 > Initial_Capacity)
            {
                throw new InvalidOperationException("Database capacity exceeded!");
            }
            this.ValidateIfUserWithSuchIdExists(person.Id);
            this.ValidateIfUserWithSuchUsernameExists(person.Username);

            this.people[this.Count] = person;
            this.Ids.Add(person.Id);
            this.Names.Add(person.Username);

            this.Count++;
        }        

        public void Remove()
        {
            if (this.Count.Equals(0))
            {
                throw new InvalidOperationException("No elements in Database!");
            }
            this.Count--;
            this.people[this.Count] = default(Person);
        }

        public Person[] Fetch()
        {
            return this.people.Take(this.Count).ToArray();
        }

        private void InitializeArray(Person[] numbers)
        {
            foreach (var element in numbers)
            {
                this.Add(element);
            }
        }

        private void ValidateIfSuchUsernameIsPresent(string username)
        {
            if (!this.Names.Contains(username))
            {
                throw new InvalidOperationException("No such username in Database!");
            }
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(username, "Username cannot be null!");
            }
        }

        private void ValidateIfSuchUserIdIsPresent(long id)
        {
            if (!this.Ids.Contains(id))
            {
                throw new InvalidOperationException("No user with this Id in Database!");
            }
        }

        private void ValidateId(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be positive number!");
            }
        }
        private void ValidateIfUserWithSuchUsernameExists(string username)
        {
            if (this.Names.Contains(username))
            {
                throw new InvalidOperationException("User with this username already exists!");
            }
        }

        private void ValidateIfUserWithSuchIdExists(long id)
        {
            if (this.Ids.Contains(id))
            {
                throw new InvalidOperationException("User with this id already exists!");
            }
        }
    }
}
