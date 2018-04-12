namespace P01_EventImplementation.Models
{
    using System;

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public event NameChangeEventHandler NameChange;

        public void OnNameChange(NameChangeEventArgs args)
        {
            NameChange?.Invoke(this, args);
        }
    }
}
