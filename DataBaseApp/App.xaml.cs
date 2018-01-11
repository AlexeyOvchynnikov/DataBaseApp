using System;
using DataBaseApp.Models;
using DataBaseApp.Repositories;
using DataBaseApp.Repositories.Interfaces;
using Xamarin.Forms;

namespace DataBaseApp
{
    public partial class App : Application
    {
        public static UserRepository Repository;
        public App()
        {
            InitializeComponent();
            Repository = new UserRepository(DependencyService.Get<ISqLiteDbPath>());
            //Repository.InsertOrUpdate(new UserModel
            //{
            //    Id = "1",
            //    FirstName = "name",
            //    LastName = "Lname",
            //    Patronymic = "Patr",
            //    Integer = 2131,
            //    Double = 1.001,
            //    RegistrationDate = DateTime.Now,

            //});
            //Repository.InsertOrUpdate(new UserModel
            //{
            //    Id = "2",
            //    FirstName = "name2",
            //    LastName = "Lname2",
            //    Patronymic = "Patr2",
            //    Integer = 354,
            //    Double = 2.001,
            //    RegistrationDate = DateTime.Now,

            //});
            MainPage = new DataBaseAppPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
