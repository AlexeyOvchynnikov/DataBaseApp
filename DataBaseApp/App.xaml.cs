using System;
using Autofac;
using Autofac.Core;
using DataBaseApp.Autofac;
using DataBaseApp.Models;
using DataBaseApp.Repositories;
using DataBaseApp.Services.Interfaces;
using Plugin.Settings;
using Xamarin.Forms;

namespace DataBaseApp
{
    public partial class App : Application
    {
        public static UserRepository Repository;
        public App(IModule platformSpecificModule)
        {
            DependencyContainer.Container = new DependenciesSetup().PrepareContainer(platformSpecificModule, new ApplicationModule());
            InitializeComponent();
            //Run();
            CrossSettings.Current.AddOrUpdateValue("DatabaseVersion", 0);
            Migration();


            MainPage = new DataBaseAppPage();
        }

        void Run()
        {
            var res = CrossSettings.Current.GetValueOrDefault("DatabaseVersion", 0);
            Repository = new UserRepository(DependencyContainer.Container.Resolve<ISqLiteConnection>());

            DependencyContainer.Container.Resolve<ISqLiteConnection>().GetDatabaseConnection().CreateTable<UserModel>();
            Repository.InsertOrUpdate(new UserModel
            {
                UserId = "1",
                FirstName = "name",
                LastName = "Lname",
                Patronymic = "Patr",
                Integer = 2131,
                Double = 1.001,
                RegistrationDate = DateTime.Now,
            });

            Repository.InsertOrUpdate(new UserModel
            {
                UserId = "2",
                FirstName = "name2",
                LastName = "Lname2",
                Patronymic = "Patr2",
                Integer = 354,
                Double = 2.001,
                RegistrationDate = DateTime.Now,
            });

            var a = Repository.GetAll();

        }
        async void Migration()
        {
            var migrationService = DependencyContainer.Container.Resolve<IMigrationService>();
            var res = CrossSettings.Current.GetValueOrDefault("DatabaseVersion", 0);
            Repository = new UserRepository(DependencyContainer.Container.Resolve<ISqLiteConnection>());

            if (await migrationService.RunMigrations())
            {
                var a = Repository.GetAll();
            }
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
