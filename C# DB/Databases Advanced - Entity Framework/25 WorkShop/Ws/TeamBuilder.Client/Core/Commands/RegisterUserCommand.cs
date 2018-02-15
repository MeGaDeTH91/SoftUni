namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class RegisterUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(7, inputArgs);

            string username = inputArgs[0];

            if(username.Length<Constants.MinUsernameLength || username.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            string password = inputArgs[1];

            if(!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            string repeatedPassword = inputArgs[2];

            if(password != repeatedPassword)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.PasswordDoesNotMatch);
            }

            string firstName = inputArgs[3];
            if(firstName.Length > 25 || string.IsNullOrWhiteSpace(firstName))
            {
                throw new InvalidOperationException("Invalid first name!");
            }

            string lastName = inputArgs[4];
            if (lastName.Length > 25 || string.IsNullOrWhiteSpace(lastName))
            {
                throw new InvalidOperationException("Invalid last name!");
            }

            int age;
            bool isNumber = int.TryParse(inputArgs[5], out age);

            if(!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            Gender gender;
            bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);

            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }

            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            this.RegisterUser(username, password, firstName, lastName, age, gender);

            
            return $"User {username} was registered successfully!";
        }

        private void RegisterUser(string username, 
                                  string password, 
                                  string firstName, 
                                  string lastName, 
                                  int age, 
                                  Gender gender)
        {
            using(var db = new TeamBuilderContext())
            {
                User u = new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };

                db.Users.Add(u);
                db.SaveChanges();
            }
        }
    }
}
