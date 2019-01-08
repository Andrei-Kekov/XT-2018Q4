using System;
using System.Collections.Generic;

namespace Epam.Task06._01_Users.PL
{
    public static class PL
    {
        public static Interfaces.IBLL bll;

        public static void Main()
        {
            Console.WriteLine("Task 6.1. Users");
            bll = Containers.BLLContainer.GetBLL();
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(A)dd user, (D)elete user, (S)how user list, e(X)it?");
            char command;

            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out command))
                {
                    switch (char.ToLower(command))
                    {
                        case 'a':
                            Add();
                            break;
                        case 'd':
                            Delete();
                            break;
                        case 's':
                            Show();
                            break;
                        case 'x':
                            return;
                        default:
                            Console.WriteLine("Wrong command.");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong command.");
                    continue;
                }
            }
        }

        private static void Add()
        {
            int id;
            string name;
            DateTime dateOfBirth;
            Console.WriteLine("Please enter the new user data:");
            Console.Write("ID: ");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID must be an integer! Try again.");
            }

            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Date of birth: ");

            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invaslid date! Try again.");
            }

            if (bll.Add(id, name, dateOfBirth))
            {
                Console.WriteLine("User successfully added.");
            }
            else
            {
                Console.WriteLine("There already is a user with this ID.");
            }
        }

        private static void Delete()
        {
            int id;
            Console.WriteLine("Please enter the id of the user you want to remove:");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID must be an integer! Try again.");
            }

            if (bll.Delete(id))
            {
                Console.WriteLine($"User {id} successfully removed");
            }
            else
            {
                Console.WriteLine($"User {id} not found.");
            }
        }

        private static void Show()
        {
            IEnumerable<int> ids = bll.GetIDs();
            Entities.User user;

            foreach (int id in ids)
            {
                user = bll.GetUser(id);
                Console.WriteLine($"User {id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Date of birth: {user.DateOfBirth.Date}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine();
            }
        }
    }
}
