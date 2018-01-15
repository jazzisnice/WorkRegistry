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
    /// Interaction logic for WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        public List<Worker> Workers {
            get
            {
                return DbOperations.GetAllWorkers();
            }
        }

        public void RefreshView(object sender, EventArgs e)
        {
            Console.Write(DbOperations.GetAllWorkers().Count());
        }

        public WorkersWindow()
        {
            InitializeComponent();
            //Workers = DbOperations.GetAllWorkers();
            //WorkerListbox.ItemsSource = Workers;
        }

        private void EditWorker(object sender, RoutedEventArgs e)
        {
            // TODO worker edit in new window
            Button button = sender as Button;
            Console.WriteLine("a");
        }

        private void AddWorker(object sender, RoutedEventArgs e)
        {
            NewWorkerWindow window = new NewWorkerWindow();
            window.Show();
            window.Closed += RefreshView;
        }
    }
}
