using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DAL.Menu
{
    public class Menu
    {
        int choice = 0;
        public void menu()
        {
            Admin adm = new Admin();
            User user = new User();
            Console.WriteLine("Login as:\n1 - Admin\n2 - User\n0 - Exit");
            Console.Write("Your choice is: ");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.Write("Enter login: "); adm.login = Console.ReadLine();
                        Console.Write("Enter password: "); adm.password = Console.ReadLine();
                        Console.Clear();
                        if (adm.login == "Arman" && adm.password == "Admin")
                        {
                                Console.WriteLine("1 - Change status\n2 - Add/Remove component\n0 - Exit");
                                Console.Write("Your choice is: ");
                                choice = Int32.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        {
                                            ChangeStatus.changeStatus();
                                            break;
                                        }
                                    case 2:
                                        {
                                            AddRemoveComp.addRemoveComp();
                                            break;
                                        }
                                    case 0:
                                        {
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                case 2:
                    {
                        Console.Clear();
                        user.LogInAsUser();
                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }
    }
}
