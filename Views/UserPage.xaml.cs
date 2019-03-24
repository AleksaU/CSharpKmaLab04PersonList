using CSharpKmaLab04PersonList.ViewModels;
using System.Windows.Controls;


namespace CSharpKmaLab04PersonList.Views
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            DataContext = new UserPageViewModel();
        }
    }
}
