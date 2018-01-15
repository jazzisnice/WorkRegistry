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
using System.Windows.Shapes;
using WorkRegistry.model;

namespace WorkRegistry.view
{
    /// <summary>
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class NewWorkerWindow : Window
    {
        public WorkersViewModel ViewModel;

        public NewWorkerWindow(WorkersViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        private void AddNewWorker(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker()
            {
                // TODO validation
                Name = WorkerNameTB.Text
            };
            ViewModel.AddWorker(worker);
            this.Close();
        }
    }
}
