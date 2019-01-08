using System;
using System.Collections.Generic;

namespace Epam.Task06._01_Users.PL
{
    public static class PL
    {
        public static Interfaces.IBLL bll;

        public static void Main()
        {
            Console.WriteLine("Task 6. Users and Awards");
            bll = Containers.BLLContainer.GetBLL();
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(1) Add user");
            Console.WriteLine("(2) Delete user");
            Console.WriteLine("(3) Award user");
            Console.WriteLine("(4) View user list");
            Console.WriteLine("(5) Create new award");
            Console.WriteLine("(6) View award list");
            Console.WriteLine("(0) Exit");
            char command;

            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case '1':
                            Add();
                            break;
                        case '2':
                            Delete();
                            break;
                        case '3':
                            AwardUser();
                            break;
                        case '4':
                            Show();
                            break;
                        case '5':
                            AddAward();
                            break;
                        case '6':
                            ShowAwards();
                            break;
                        case '0':
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
                Console.Write($"Awards: ");

                if (user.Awards.Count == 0)
                {
                    Console.WriteLine("none");
                }
                else
                {
                    foreach (int award in user.Awards)
                    {
                        Console.Write($"{bll.GetAward(award).Name}, ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void AwardUser()
        {
            IEnumerable<int> ids = bll.GetIDs();
            Entities.User user;
            Entities.Award award;
            int userID;
            int awardID;
            Console.WriteLine("Which user do you want to award?");

            foreach (int id in ids)
            {
                user = bll.GetUser(id);
                Console.WriteLine($"({id}) {user.Name}");
            }

            if (!int.TryParse(Console.ReadLine(), out userID))
            {
                Console.WriteLine("Bad user ID.");
                return;
            }

            Console.WriteLine("Which award do you want to give?");
            ids = bll.GetAwardIDs();

            foreach (int id in ids)
            {
                award = bll.GetAward(id);
                Console.WriteLine($"({id}) {award.Name}");
            }

            if (!int.TryParse(Console.ReadLine(), out awardID))
            {
                Console.WriteLine("Bad award ID.");
                return;
            }

            if (bll.AwardUser(userID, awardID))
            {
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine($"Can't award user {userID} with award {awardID}.");
            }
        }

        private static void AddAward()
        {
            int id;
            string name;
            Console.WriteLine("Please enter the new award data:");
            Console.Write("ID: ");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID must be an integer! Try again.");
            }

            Console.Write("Name: ");
            name = Console.ReadLine();

            if (bll.AddAward(id, name))
            {
                Console.WriteLine("Award successfully added.");
            }
            else
            {
                Console.WriteLine("There already is an award with this ID.");
            }
        }

        private static void ShowAwards()
        {
            IEnumerable<int> ids = bll.GetAwardIDs();
            Entities.Award award;

            foreach (int id in ids)
            {
                award = bll.GetAward(id);
                Console.WriteLine($"Award {id}: {award.Name}");
            }
        }
    }
}
