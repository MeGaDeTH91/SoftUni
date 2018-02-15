namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public static string Execute(string[] data)
        {
            string username = data[1];
            string property = data[2].ToLower();
            string newValue = data[3];

            using(var context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == username);

                if(user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }
                if(Session.User == null || user.Username != Session.User.Username)
                {
                    throw new ArgumentException($"Invalid credentials!");
                }
                string excMessage = $"Value {newValue} not valid." + Environment.NewLine;
                string townError = $"Town {newValue} not found!";

                switch (property)
                {
                    case "password":
                        if(!newValue.Any(x => Char.IsLower(x)) 
                        || !newValue.Any(x => Char.IsDigit(x)))
                        {
                            throw new ArgumentException(excMessage +
                                "Invalid Password");
                        }
                        user.Password = newValue;
                        break;
                    case "borntown":
                        var bornTown = context.Towns
                            .Where(x => x.Name == newValue)
                            .FirstOrDefault();

                        if(bornTown == null)
                        {
                            throw new ArgumentException(excMessage + townError);
                        }
                        user.BornTown = bornTown;
                        break;
                    case "currenttown":
                        var currTown = context.Towns
                            .Where(x => x.Name == newValue)
                            .FirstOrDefault();

                        if (currTown == null)
                        {
                            throw new ArgumentException(excMessage + townError);
                        }
                        user.CurrentTown = currTown;
                        break;
                    default:
                        throw new ArgumentException($"Property {property} not supported!");
                }

                context.SaveChanges();                
            }
            return $"User {username} {property} is {newValue}.";
        }
    }
}
