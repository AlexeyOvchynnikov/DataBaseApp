using Xamarin.Forms;

namespace DataBaseApp
{
    public partial class DataBaseAppPage : ContentPage
    {
        public DataBaseAppPage()
        {
            InitializeComponent();
            var users = App.Repository.GetAll();
            foreach (var user in users)
            {
                LabelS.Text += user.FirstName + "\n" + user.Id + "\n" + user.LastName + "\n" + user.Patronymic + "\n" + user.Double + "\n" + user.RegistrationDate + "\n" + user.Integer + "\n";
            }
        }
    }
}
