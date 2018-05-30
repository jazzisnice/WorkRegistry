using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkRegistry.view;
using SQLite;
using WorkRegistry.model;
using WorkRegistry.viewmodel;

namespace WorkRegistry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private WorksViewModel worksViewModel;

        public MainWindow()
        {
            DbOperations.InitDatabase();
            this.worksViewModel = new WorksViewModel();
            InitializeComponent();
            WorksItemsControl.ItemsSource = worksViewModel.GetAllWorks();
        }

        private void WorkersButton_Click(object sender, RoutedEventArgs e)
        {
            WorkersWindow window = new WorkersWindow();
            window.Show();
        }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsWindow window = new TeamsWindow(new TeamsViewModel());
            window.Show();
        }

        private void CarsButton_Click(object sender, RoutedEventArgs e)
        {
            CarsWindow window = new CarsWindow(new CarsViewModel());
            window.Show();
        }

        private void JobsButton_Click(object sender, RoutedEventArgs e)
        {
//            WorksWindow worksWindow = new WorksWindow(new WorksViewModel());
//            worksWindow.Show();
        }

        private void AddWork_Click(object sender, RoutedEventArgs e)
        {
            Work work = new Work();
            NewWorkWindow newWorkWindow = new NewWorkWindow(worksViewModel, work);
            newWorkWindow.Show();
        }
    }
}
