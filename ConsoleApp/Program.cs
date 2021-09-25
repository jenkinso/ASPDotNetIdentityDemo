using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userStore = new UserStore<IdentityUser>(); // UserStore ==> abstraction of underlying storage layer (database). We'll be using existing EF implementation
            var userManager = new UserManager<IdentityUser>(userStore); // contains CRUD methods for managing identity data (including managing passwords, claims and roles for a user)

            var creationResult = userManager.Create(new IdentityUser("demoUser"), "Password123!");

            Console.WriteLine($"Creating a user was successful? {creationResult.Succeeded}. Error count: {creationResult.Errors.Count()}.");
            
            Console.ReadLine();
        }
    }
}
