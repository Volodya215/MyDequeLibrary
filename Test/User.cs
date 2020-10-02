using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace TrackLab_1
{
    public class User
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        private string _password;

        public User(string name, string surname, string password)
        {
            Name = name;
            Surname = surname;

            if (CheckPassword(password))
                _password = password;
            else
                _password = "11111";
        }

        private bool CheckPassword(string pass) => pass.Length > 3;

        public void ChangePassword()
        {
            Console.Write("Enter your password: ");
            string pass = Console.ReadLine();

            if (pass == _password)
            {
                Console.Write("Enter new password: ");
                string temp = Console.ReadLine();

                if (CheckPassword(temp))
                {
                    _password = temp;
                    Console.WriteLine("Password change successful");
                }
                else
                    Console.WriteLine("Incorrect new password");
            }
            else
                Console.WriteLine("Access denied!!!");
        }

        public override string ToString() => Name + " " + Surname;

    }
}
