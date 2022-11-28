﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamGrapeBankApp
{
    internal abstract class User
    {
        //Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //List to hold users
        public static List<User> userList = new List<User>();

        //Constructor
        public User(int id, string username, string password, string firstname, string lastname)
        {
            Id = id;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
        }

        //Method to login user
        internal static void Login()
        {
            //Create User objects as Admin and Customers and add to list
            //This should be handled by a database in the future
            User sven = new Customer(1, "billgates", "pass1", "Bill", "Gates", "Nygatan 26 31176 Falkenberg", "bill@microsoft.se", "+46702222222", false);
            User anna = new Customer(2, "annasvensson", "pass2", "Anna", "Svensson", "Nygatan 26 31176 Falkenberg", "anna@svensson.se", "+46703333333", false);
            User hermes = new Customer(3, "hermessaliba", "pass3", "Hermes", "Saliba", "Nygatan 28 31176 Falkenberg", "hermes@gmail.com", "+46704444444", false);
            User admin = new Admin(4, "admin", "pass", "Anas", "Qlok");

            
            userList.Add(sven);
            userList.Add(anna);
            userList.Add(hermes);
            userList.Add(admin);

            //Welcome message and login logic
            //Loop while entered username doesnt exist
            Console.Clear();
            Console.WriteLine("Welcome the the bank\n");
            string enteredUsername;
            do
            {
                Console.Write("Enter username: ");
                enteredUsername = Console.ReadLine();
            } while (!userList.Any(x => x.Username == enteredUsername));

            //Store found user in userTryLogin
            User userTryLogin = userList.Find(x => x.Username == enteredUsername);

            //Loop while there are logintries left or login is not successful
            int loginTries = 3;
            bool loginSuccess = false;
            do
            {
                
                Console.Write($"Enter password, you have {loginTries} tries left: ");
                string enteredPassword = Console.ReadLine();
                loginTries--;
                if (enteredPassword == userTryLogin.Password)
                {
                    loginSuccess = true;
                }
            } while (loginTries > 0 && loginSuccess == false);

            //Logic to check if login is successful, change later
            if (loginSuccess == true && userTryLogin is Admin)
            {
                Admin.AdminMenu(userTryLogin);
            }
            else if (loginSuccess == true && userTryLogin is Customer)
            {
                Customer.CustomerMenu(userTryLogin);
            }
            else
            {
                Console.WriteLine($"User {userTryLogin.Username} is locked from login");
            }
        }
    }
}