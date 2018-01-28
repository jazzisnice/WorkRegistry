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
using WorkRegistry.viewmodel;

namespace WorkRegistry.view
{
    /// <summary>
    /// Interaction logic for CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        public CarsViewModel ViewModel { get; set; }

        public CarsWindow(CarsViewModel carsViewModel)
        {
            ViewModel = carsViewModel;
            InitializeComponent();

            carsListBox.ItemsSource = ViewModel.Cars;
        }

        private void ModifyCar(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            NewCarWindow window = new NewCarWindow(new NewCarViewModel(ViewModel, null));
            window.Show();
        }
    }
}
