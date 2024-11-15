using Formation.EmployerApp.ViewModels;
using System.Windows.Controls;

namespace Formation.EmployerApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for EmployerPage.xaml
    /// </summary>
    public partial class EmployerPage : UserControl
    {
        public EmployerPage()
        {
            InitializeComponent();
            DataContext = new EmployerViewModel();
        }
    }
}
