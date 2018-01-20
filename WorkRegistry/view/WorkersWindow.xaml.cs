using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using WorkRegistry.model;

namespace WorkRegistry.view
{
    /// <summary>
    /// Interaction logic for WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        private WorkersViewModel ViewModel = new WorkersViewModel();

        public WorkersWindow()
        {
            InitializeComponent();
            WorkersListBox.ItemsSource = ViewModel.Workers;
            ViewModel.PropertyChanged += RefreshView;
        }

        public void RefreshView(object sender, PropertyChangedEventArgs e)
        {
            WorkersListBox.InvalidateArrange();
            WorkersListBox.UpdateLayout();
        }

        private void EditWorker(object sender, RoutedEventArgs e)
        {
            var Sender = sender as Button;
            NewWorkerWindow window = new NewWorkerWindow(ViewModel, Sender.DataContext as Worker);
            window.Show();
        }

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            NewWorkerWindow window = new NewWorkerWindow(ViewModel, new Worker());
            window.Show();
        }

        private void DeleteWorker(object sender, RoutedEventArgs e)
        {
            var Sender = sender as Button;
            ViewModel.DeleteWorker(Sender.DataContext as Worker);

        }

    }
}
