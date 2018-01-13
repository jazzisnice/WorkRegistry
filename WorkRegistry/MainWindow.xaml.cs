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

namespace WorkRegistry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DbOperations.InitDatabase();
        }

        private void WorkersButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow window = new WorkerWindow();
            window.Show();
            Console.WriteLine("Opened window");
        }
    }
}
