using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_adressbok_v45
{
    class Program
    {
        class PersonalInfo
        {
            public string name, adress, email, phoneNumber;
            
            public PersonalInfo(string N, string A, string PN, string E)
            {
                name = N;
                adress = A;
                email = E;
                phoneNumber = PN;
            }
        }
        static void Main(string[] args)
        {
            string fileName = @" C:\Users\basma\adressbok.txt";
            
            List<PersonalInfo> person = new List<PersonalInfo>();
            

            // Read the file as one string.

            using (StreamReader file = new StreamReader(fileName))
            {
                

                while ((fileName = file.ReadLine()) != null)
                {
                    string[] info = fileName.Split(',');
                    // Console.WriteLine(line);
                    // Console.WriteLine("{0} - {1}", words[0], words[1]);
                    person.Add(new PersonalInfo(info[0], info[1], info[2], info[3]));
                }
                file.Close();
            }

            string command;
            do
            {
                Console.WriteLine("welcome to your file text adressbok.txt");
                Console.WriteLine("write 'add' if you want to add a new person's info 'name, adress, phonenumber and email'");
                Console.WriteLine("write 'save' to save the persnol info");
                Console.WriteLine("write 'delete' if you want to delete the personal information");
                Console.WriteLine("write 'quite' to quite the program");
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "quite")
                {
                    Console.WriteLine("Good bye!");
                }
                else if (command == "add")
                {
                    Console.Write("enter your name, adress, phonenumber and email : ");
                    string N = Console.ReadLine();
                    string A = Console.ReadLine();
                    string PN = Console.ReadLine();
                    string E = Console.ReadLine();

                    Console.WriteLine($"{N} {A} {PN} {E}");
                    person.Add(new PersonalInfo(N, A, PN, E));
                
                }
                else if (command == "save")
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        for (int i = 0; i < person.Count(); i++)
                        {
                            writer.WriteLine("{0},{1},{2},{3}", person[i].name, person[i].adress, person[i].phoneNumber, person[i].email);
                        }
                    }
                }
                else if (command == "delete")
                {
                    Console.Write("Ange det engelska ordet: ");
                    string N = Console.ReadLine();
                    string A = Console.ReadLine();
                    string PN = Console.ReadLine();
                    string E = Console.ReadLine();
                    for (int i = 0; i < person.Count(); i++)
                    {
                        if (N == person[i].name)
                        {
                            Console.WriteLine($"hittade {N} på index {i}");
                            person.RemoveAt(i);
                        }
                        else if (A == person[i].adress)
                        {
                            Console.WriteLine($"hittade {A} på index {i}");
                            person.RemoveAt(i);
                        }
                        else if (PN == person[i].phoneNumber)
                        {
                            Console.WriteLine($"hittade {PN} på index {i}");
                            person.RemoveAt(i);
                        }
                        else if (E == person[i].email)
                        {
                            Console.WriteLine($"hittade {E} på index {i}");
                            person.RemoveAt(i);
                        }

                    }
                }
               
                else if (command == "show")
                {
                    
                    for (int i = 0; i < person.Count(); i++)
                    {
                        if (person[i] != null)
                        {
                            Console.WriteLine("{0,-10}{1,-20}",
                                              person[i].name, person[i].adress, person[i].phoneNumber, person[i].email);
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine($"Okänt kommando: {command}");
                }
            } while (command != "quite");
        }
    }
    
}
