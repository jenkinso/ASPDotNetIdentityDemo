using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userStore = new UserStore<IdentityUser>(); // UserStore ==> abstraction of underlying storage layer (database). We'll be using existing EF implementation
            var userManager = new UserManager<IdentityUser>(userStore); // contains CRUD methods for managing identity data (including managing passwords, claims and roles for a user)

            /* // Creating a User demo
            var creationResult = userManager.Create(new IdentityUser("demoUser"), "Password123!");
            Console.WriteLine($"Creating a user was successful? {creationResult.Succeeded}. Error count: {creationResult.Errors.Count()}.");
            */

            // Adding a Claim demo
            var user = userManager.FindByName("demoUser");
            var claimResult = userManager.AddClaim(user.Id, new Claim("given_name", "Owen")); // You can add the same claim_type twice??
            Console.WriteLine($"Claim succeeded? {claimResult.Succeeded}.");

            Console.ReadLine();
        }
    }
}
