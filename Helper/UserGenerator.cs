using Bogus;
using Demant_Assignment.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demant_Assignment.Application.Helper
{
    public static class UserGenerator
    {
     
        public static List<Users> GenerateFakeUsers()
        {
            var onlineStatus = new[] {true, false};

            var testUsers = new Faker<Users>()
    
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Country, f => f.Address.Country())
            .RuleFor(u => u.BirthDate, f => f.Date.Past(50, DateTime.Now))
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(null, null))
            .RuleFor( u=> u.Status, f => f.PickRandom(onlineStatus));
            var listOfUsers = testUsers.Generate(9);

            var customDateTime = DateTime.Now;
            var customUser = new Users
            {
                BirthDate = customDateTime.AddYears(-26),
                Country = "Malaysia",
                Name = "Wing Han",
                UserName = "whan97",
                Status = true
            };

            listOfUsers.Add(customUser);
            return listOfUsers;
        }
    }
}
