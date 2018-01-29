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
        public Worker CurrentWorker
        {
            get;
            set;
        }

        // We are either adding or editing a current worker
        public NewWorkerWindow(WorkersViewModel viewModel, Worker currentWorker)
        {
            ViewModel = viewModel;
            if (currentWorker == null)
                CurrentWorker = new Worker();
            else
                CurrentWorker = currentWorker;
            this.DataContext = this;
            InitializeComponent();
        }

        private void AddNewWorker(object sender, RoutedEventArgs e)
        {
            ViewModel.AddOrEditWorker(CurrentWorker);
            this.Close();
        }
    }
}