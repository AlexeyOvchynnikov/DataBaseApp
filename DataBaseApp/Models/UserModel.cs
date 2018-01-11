
using SQLite;
using System;

namespace DataBaseApp.Models
{
    public class UserModel
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int Integer { get; set; }

        public DateTime RegistrationDate { get; set; }

        public double Double { get; set; }



    }
}
