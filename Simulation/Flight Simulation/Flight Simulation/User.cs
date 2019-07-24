using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Simulation
{
    class User
    {
        private string name;
        private string surname;
        private string gender;

        private string username;
        private string password;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User()
        {

        }

        public User(string name, string surname, string gender, string username, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Username = username;
            this.Password = password;
        }

        public override string ToString()
        {
            return name + ',' + surname + ',' + gender + ',' + username + ',' + password;
        }

        public void AddUsers()
        {
            FileHandler fh = new FileHandler();
            fh.WriteData("login.txt", ToString());
        }

        public List<User> PopulateUsers()
        {
            List<User> users = new List<User>();
            FileHandler fh = new FileHandler();
            List<string> data = fh.ReadData("login.txt");

            foreach (string item in data)
            {
                string[] values = item.Split(',');
                users.Add(new User(values[0], values[1], values[2], values[3], values[4]));
            }

            return users;
        }
    }
}