namespace P02_ExtendedDatabase
{
    using System;

    public class Person
    {
        private long id;
        private string username;

        public Person(long id, string name)
        {
            this.Id = id;
            this.Username = name;
        }
        
        public long Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }
        public string Username
        {
            get { return this.username; }
            private set { this.username = value; }
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Username: {this.Username};";
        }
    }
}
