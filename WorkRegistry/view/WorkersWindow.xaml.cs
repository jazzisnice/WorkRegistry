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
        public WorkersWindow()
        {
            InitializeComponent();
            WorkerListbox.ItemsSource = Workers;
        }

        public List<Worker> Workers
        {
            get
            {
                return DbOperations.GetAllWorkers();
            }
        }

        public void TestEvent(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("aa");
        }

        private void EditWorker(object sender, RoutedEventArgs e)
        {
            // TODO worker edit in new window
            Button button = sender as Button;
            Console.WriteLine("a");
        }
    }
}
